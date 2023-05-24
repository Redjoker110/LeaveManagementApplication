using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.Repositries;
using LeaveManagementApplication.Persistence.DbContext;
using LeaveManagementApplication.Persistence.Repositries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementApplication.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LeaveManagementDbContext>(x => x
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                a => a.MigrationsAssembly(typeof(LeaveManagementDbContext).Assembly.FullName)));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
    }
}