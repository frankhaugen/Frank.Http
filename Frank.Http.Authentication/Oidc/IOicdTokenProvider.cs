namespace Frank.Http.Authentication.Oidc;

public interface IOicdTokenProvider
{
    Task<string> GetTokenAsync(CancellationToken cancellationToken);
}