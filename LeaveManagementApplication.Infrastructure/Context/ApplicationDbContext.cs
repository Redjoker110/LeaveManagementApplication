using LeaveManagementApplication.Application;
using LeaveManagementApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //LeaveAllocations
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    //LeaveType
    public DbSet<LeaveType> LeaveType { get; set; }

    //LeaveRequest
    public DbSet<LeaveRequest> LeaveRequest { get; set; }


    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}