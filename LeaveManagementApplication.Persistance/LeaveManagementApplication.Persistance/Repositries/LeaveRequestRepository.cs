using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistence.Repositries;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
    {
        var leaveRequest = _dbContext.LeaveRequest
            .Include(x => x.leaveType)
            .FirstOrDefaultAsync(x => x.Id == Id);
        return leaveRequest.Result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsList()
    {
        var leaveRequest = await _dbContext.LeaveRequest
            .Include(x => x.leaveType)
            .ToListAsync();
        return leaveRequest;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus)
    {
        leaveRequest.approved = ApprovalStatus;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}