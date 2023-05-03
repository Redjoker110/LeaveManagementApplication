using LeaveManagementApplication.Domain.Common;
using LeaveManagementApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistance.DbContext;

public class LeaveManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
    {
    }

    //LeaveAllocations
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    //LeaveType
    public DbSet<LeaveType> LeaveType { get; set; }

    //LeaveRequest
    public DbSet<LeaveRequest> LeaveRequest { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditEntity<DateTime>>())
        {
            entry.Entity.ModifyDate = DateTime.Now;

            if (entry.State == EntityState.Added) entry.Entity.CreatedDate = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=leavemanagementdb;Username=postgres;Password=postgres;");
        }
    }
}