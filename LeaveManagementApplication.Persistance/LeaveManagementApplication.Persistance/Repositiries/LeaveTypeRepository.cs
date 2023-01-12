using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveManagementApplication.Domain.Models;
using LeaveManagementApplication.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistance.Repositiries
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<LeaveType> GetLeaveTypeWithDetails(int Id);
        Task<List<LeaveType>> GetLeaveTypesList();
        Task<LeaveType> AddLeaveType(LeaveType leaveType);


    }

    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {

        private readonly LeaveManagementDbContext _dbContext;
        
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<LeaveType> GetLeaveTypeWithDetails(int Id)
        {
            var leaveType = _dbContext.LeaveType
                .FirstOrDefaultAsync(x => x.Id == Id);


             return leaveType.Result;
        }

        public async Task<List<LeaveType>> GetLeaveTypesList()
        {
            var leaveRequest = await _dbContext.LeaveType
                .ToListAsync();
            return leaveRequest;
        }

        public async Task<LeaveType> AddLeaveType(LeaveType leaveType)
        {
            await _dbContext.AddAsync(leaveType);
            await _dbContext.SaveChangesAsync();
            return leaveType;
        }
    }
}
