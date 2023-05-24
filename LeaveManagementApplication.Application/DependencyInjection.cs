using System.Reflection;
using LeaveManagementApplication.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementApplication.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped(typeof(ILoggingService<>), typeof(LoggingService<>));
    }
}