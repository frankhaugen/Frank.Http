﻿using System.Net.Http.Headers;
using Frank.Http.Abstractions;

namespace Frank.Http.Authentication.Oidc;

public class OidcAuthentication : IHttpAuthentication
{
    private readonly IOicdTokenProvider _tokenProvider;

    public OidcAuthentication(IOicdTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenProvider.GetTokenAsync(cancellationToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}