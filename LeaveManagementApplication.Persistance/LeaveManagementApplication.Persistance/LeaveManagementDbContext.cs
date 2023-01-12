using LeaveManagementApplication.Application;
using LeaveManagementApplication.Domain.Common;
using LeaveManagementApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Infrastructure.Context;

public class LeaveManagementDbContext : DbContext, IApplicationDbContext
{
    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditEntity<DateTime>>())
        {
            entry.Entity.ModifyDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    //LeaveAllocations
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    //LeaveType
    public DbSet<LeaveType> LeaveType { get; set; }

    //LeaveRequest
    public DbSet<LeaveRequest> LeaveRequest { get; set; }


   
}