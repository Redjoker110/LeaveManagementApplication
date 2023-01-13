using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.IRepositories
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsList();






    }

    
}
