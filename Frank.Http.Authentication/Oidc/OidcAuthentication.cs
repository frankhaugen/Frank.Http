using System.Net.Http.Headers;
using System.Text.Json;
using Frank.Http.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Frank.Http.Authentication.Oidc;

public class OidcAuthentication : IHttpAuthentication
{
    private readonly IOicdTokenProvider _tokenProvider;

    public OidcAuthentication(IOicdTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenProvider.GetTokenAsync(cancellationToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}

public class OidcTokenProvider : IOicdTokenProvider
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly IOptions<OidcAuthenticationConfiguration> _options;
    
    private string _tokenKey => $"oidc-token";

    public OidcTokenProvider(HttpClient httpClient, IOptions<OidcAuthenticationConfiguration> options, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _options = options;
        _cache = cache;
    }

    public async Task<string> GetTokenAsync(CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue<string>(_tokenKey, out var token))
        {
            return token;
        }
        var request = new HttpRequestMessage(HttpMethod.Post, _options.Value.TokenEndpoint);
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = _options.Value.ClientId,
            ["client_secret"] = _options.Value.ClientSecret,
            ["scope"] = _options.Value.Scope
        });

        var response = await _httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(content);
        _cache.Set(_tokenKey, tokenResponse.AccessToken, TimeSpan.FromSeconds(300));

        return token;
    }

    private record TokenResponse(string AccessToken);
}