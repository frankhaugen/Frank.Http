using Frank.Http.Abstractions;

namespace Frank.Http;

public class RestClientFactory(IHttpClientFactory httpClientFactory, IEnumerable<IRequestEnricher> enrichers, IEnumerable<IHttpAuthentication> authentications) : IRestClientFactory
{
    /// <inheritdoc />
    public IRestClient CreateClient(bool vanilla = false) =>
        vanilla 
            ? new RestClient(httpClientFactory.CreateClient(), [], []) 
            : new RestClient(httpClientFactory.CreateClient(), authentications, enrichers);

    /// <inheritdoc />
    public IRestClient CreateClient(IEnumerable<IRequestEnricher> enricherCollection, IEnumerable<IHttpAuthentication> authenticationCollection) => new RestClient(httpClientFactory.CreateClient(), authenticationCollection, enricherCollection);
}