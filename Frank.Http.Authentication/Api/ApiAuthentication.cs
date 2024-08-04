using Frank.Http.Abstractions;
using Microsoft.Extensions.Options;

namespace Frank.Http.Authentication.Api;

public class ApiKeyAuthentication : IHttpAuthentication
{
    private readonly IOptions<ApiAuthenticationConfiguration> _options;

    public ApiKeyAuthentication(IOptions<ApiAuthenticationConfiguration> options)
    {
        _options = options;
    }
    
    public Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add(_options.Value.HeaderName, _options.Value.ApiKey);
        return Task.CompletedTask;
    }
}