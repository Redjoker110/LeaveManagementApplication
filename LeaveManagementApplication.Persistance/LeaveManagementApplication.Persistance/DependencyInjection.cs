using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementApplication.Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<LeaveManagementDbContext>(x => x
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),a=>a.MigrationsAssembly(typeof(LeaveManagementDbContext).Assembly.FullName)));

            services.AddScoped<LeaveManagementDbContext>(provider =>
                provider.GetRequiredService<LeaveManagementDbContext>());




        }


    }
}
