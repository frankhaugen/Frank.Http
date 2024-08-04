namespace Frank.Http.Abstractions;

public interface IRestClientFactory
{
    IRestClient CreateClient();
}