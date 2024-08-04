namespace Frank.Http.Abstractions;

public interface IRestClient
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}