namespace Frank.Http.Abstractions;

public interface IRequestEnricher
{
    void Enrich(HttpRequestMessage request);
}