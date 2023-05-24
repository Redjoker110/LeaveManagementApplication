using LeaveManagementApplication.Application.Extensions;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Persistence.DbContext;
using LeaveManagementApplication.Persistence.Repositries;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Application.Repositries;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
       
    }

    
}