using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}