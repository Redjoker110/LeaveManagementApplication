using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistence.Repositries;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _context;

    public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
    {
        var leaveAllocation = _context.LeaveAllocations
            .Include(x => x.leaveType)
            .FirstOrDefaultAsync(x => x.Id == Id);
        return leaveAllocation.Result;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsList()
    {
        var leaveAllocation = _context.LeaveAllocations
            .Include(x => x.leaveType)
            .ToListAsync();
        return leaveAllocation.Result;
    }
}