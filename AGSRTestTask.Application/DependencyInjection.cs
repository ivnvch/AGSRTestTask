using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AGSRTestTask.Application;

public static class DependencyInjection
{
    public static IServiceCollection ApplicationExtension(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        
        return services;
    }
}