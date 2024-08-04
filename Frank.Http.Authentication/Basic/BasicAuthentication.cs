using System.Net.Http.Headers;
using System.Text;
using Frank.Http.Abstractions;
using Microsoft.Extensions.Options;

namespace Frank.Http.Authentication.Basic;

public class BasicAuthentication(IOptions<BasicAuthenticationConfiguration> options) : IHttpAuthentication
{

    public Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{options.Value.Username}:{options.Value.Password}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        return Task.CompletedTask;
    }
}

