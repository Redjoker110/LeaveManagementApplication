using LeaveManagementApplication.Application;
using LeaveManagementApplication.Persistence;

namespace LeaveManagementApplication.Api.IOC;

public static class ContainerSetup
{
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddPersistence(configuration);
    }
}