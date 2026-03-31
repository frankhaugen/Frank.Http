using System.Net;
using System.Text;
using Frank.Http.Authentication.Oidc;
using Frank.Http.Tests.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using TUnit.Core;

namespace Frank.Http.Tests;

public class OidcTokenProviderHttpErrorTests
{
    [Test]
    public async Task GetTokenAsync_WhenTokenEndpointReturnsError_ThrowsHttpRequestException()
    {
        var handler = new StubHttpMessageHandler
        {
            SendAsyncImpl = (_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("invalid_client", Encoding.UTF8, "text/plain")
            })
        };
        using var http = new HttpClient(handler, disposeHandler: true);
        var options = Options.Create(new OidcAuthenticationConfiguration
        {
            ClientId = "a",
            ClientSecret = "b",
            Scope = "c",
            TokenEndpoint = "https://idp.test/token"
        });
        using var cache = new MemoryCache(new MemoryCacheOptions());
        var sut = new OidcTokenProvider(http, options, cache);

        await Assert.That(async () => await sut.GetTokenAsync(CancellationToken.None))
            .Throws<HttpRequestException>();
    }
}
