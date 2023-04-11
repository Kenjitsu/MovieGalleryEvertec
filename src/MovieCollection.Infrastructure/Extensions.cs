using Microsoft.Extensions.DependencyInjection;
using MovieCollection.Core.Interfaces.Services;
using MovieCollection.Infrastructure.ThirdParty.OMDbAPI;

namespace MovieCollection.Infrastructure;

public static class Extensions
{
    /// <summary>
    /// Método para implementar la inyección de dependencias.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IOMDbMoviesService, OMDbMoviesService>();


        return services;
    }
}