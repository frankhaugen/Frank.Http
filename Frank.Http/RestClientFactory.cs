using Frank.Http.Abstractions;

namespace Frank.Http;

public class RestClientFactory(IHttpClientFactory httpClientFactory, IEnumerable<IRequestEnricher> enrichers, IEnumerable<IHttpAuthentication> authentications) : IRestClientFactory
{
    /// <inheritdoc />
    public IRestClient CreateClient() => new RestClient(httpClientFactory.CreateClient(), authentications, enrichers);
}