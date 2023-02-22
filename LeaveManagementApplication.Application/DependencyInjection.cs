using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementApplication.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());


        return services;
    }
}