namespace Frank.Http.Authentication.Oidc;

public class OidcAuthenticationConfiguration
{
    public string Authority { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Scope { get; set; }
    public string RedirectUri { get; set; }
    public string ResponseType { get; set; }
    public string ResponseMode { get; set; }
    public string? TokenEndpoint { get; set; } = "connect/token";
}