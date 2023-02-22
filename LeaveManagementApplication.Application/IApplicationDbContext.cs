using LeaveManagementApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Application;

public interface IApplicationDbContext
{
    //LeaveAllocations
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    //LeaveType
    public DbSet<LeaveType> LeaveType { get; set; }

    //LeaveRequest
    public DbSet<LeaveRequest> LeaveRequest { get; set; }
}