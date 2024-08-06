using Frank.Http.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.Http;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFrankHttp(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddSingleton<IRestClientFactory, RestClientFactory>();
        services.AddTransient<IRestClient>(provider => provider.GetRequiredService<IRestClientFactory>().CreateClient());
        return services;
    }
    
    public static IServiceCollection AddFrankHttp(this IServiceCollection services, Action<IEnricherBuilder> configureEnrichers)
    {
        services.AddHttpClient();
        services.AddSingleton<IRestClientFactory, RestClientFactory>();
        services.AddTransient<IRestClient>(provider => provider.GetRequiredService<IRestClientFactory>().CreateClient());
        var enricherBuilder = new EnricherBuilder(services);
        configureEnrichers(enricherBuilder);
        return services;
    }
    
    public static IServiceCollection AddFrankHttp(this IServiceCollection services, Action<IAuthenticationBuilder> configureAuthentications)
    {
        services.AddHttpClient();
        services.AddSingleton<IRestClientFactory, RestClientFactory>();
        services.AddTransient<IRestClient>(provider => provider.GetRequiredService<IRestClientFactory>().CreateClient());
        var authenticationBuilder = new AuthenticationBuilder(services);
        configureAuthentications(authenticationBuilder);
        return services;
    }
    
    public static IServiceCollection AddFrankHttp(this IServiceCollection services, Action<IEnricherBuilder> configureEnrichers, Action<IAuthenticationBuilder> configureAuthentications)
    {
        services.AddHttpClient();
        services.AddSingleton<IRestClientFactory, RestClientFactory>();
        services.AddTransient<IRestClient>(provider => provider.GetRequiredService<IRestClientFactory>().CreateClient());
        var enricherBuilder = new EnricherBuilder(services);
        configureEnrichers(enricherBuilder);
        var authenticationBuilder = new AuthenticationBuilder(services);
        configureAuthentications(authenticationBuilder);
        return services;
    }
}