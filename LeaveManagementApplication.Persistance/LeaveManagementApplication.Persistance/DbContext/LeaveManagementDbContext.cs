using LeaveManagementApplication.Domain.Common;
using LeaveManagementApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistence.DbContext;

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

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<IAuditEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifyDate = DateTime.Now;


            if (entry.State == EntityState.Added) entry.Entity.CreatedDate = DateTime.Now;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=leavemanagementdb;Username=postgres;Password=postgres;");
    }
}