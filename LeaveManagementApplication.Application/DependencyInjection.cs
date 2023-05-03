using System.Reflection;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.Services;
using LeaveManagementApplication.Persistance.Repositries;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementApplication.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
      
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped(typeof(ILoggingService<>), typeof(LoggingService<>));
        services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
    }
}