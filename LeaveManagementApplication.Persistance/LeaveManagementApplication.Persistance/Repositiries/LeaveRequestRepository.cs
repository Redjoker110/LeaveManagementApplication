using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistance.Repositiries
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
        Task<List<LeaveRequest>> GetLeaveRequestsList();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus);


    }

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
                .FirstOrDefaultAsync(x => x.Id==Id);
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
}
