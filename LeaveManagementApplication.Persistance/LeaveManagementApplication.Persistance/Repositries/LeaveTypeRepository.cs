using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Persistence.DbContext;
using LeaveManagementApplication.Persistence.Repositries;

namespace LeaveManagementApplication.Application.Repositries;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
    }
}