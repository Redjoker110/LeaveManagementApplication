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
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsList();






    }

    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = _dbContext.LeaveAllocations
                .Include(x => x.leaveType)
                .FirstOrDefaultAsync(x => x.Id == Id);
            return leaveAllocation.Result;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsList()
        {
            var leaveAlllocation = _dbContext.LeaveAllocations
                .Include(x => x.leaveType)
                .ToListAsync();
            return leaveAlllocation.Result;
        }
    }
}
