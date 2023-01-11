using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models
{
    public class LeaveAllocation : AuditEntity<int>
    {
        public int Id { get;set; }
        public int numberOfDays { get;set; }
        public LeaveType leaveType { get;set; }
        public int leaveTypeId { get;set; }
        public int period { get;set; }

        public LeaveManagementApplication.Application.ViewModels.LeaveAllocationViewModel Equals()
        {
            throw new NotImplementedException();
        }
    }
}
