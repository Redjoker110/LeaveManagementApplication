using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.IRepositories;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
    Task<List<LeaveRequest>> GetLeaveRequestsList();
    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus);
}