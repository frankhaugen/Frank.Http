﻿namespace Frank.Http.Authentication.Oidc;

public class OidcAuthenticationConfiguration
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Scope { get; set; }
    public string? TokenEndpoint { get; set; } = "connect/token";
}