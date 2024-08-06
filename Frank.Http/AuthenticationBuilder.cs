using Frank.Http.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.Http;

public class AuthenticationBuilder : IAuthenticationBuilder
{
    private readonly IServiceCollection _services;

    public AuthenticationBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public IAuthenticationBuilder AddAuthentication<T>() where T : class, IHttpAuthentication
    {
        _services.AddSingleton<T>();
        return this;
    }

    public IAuthenticationBuilder AddAuthentication<T>(T authentication) where T : class, IHttpAuthentication
    {
        _services.AddSingleton<IHttpAuthentication>(authentication);
        return this;
    }
}