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
        public int Id { get; private set; }
        public int numberOfDays { get; private set; }
        public LeaveType leaveType { get; private set; }
        public int leaveTypeId { get; private set; }
        public int period { get; private set; }

        public LeaveManagementApplication.Application.ViewModels.LeaveAllocationViewModel Equals()
        {
            throw new NotImplementedException();
        }
    }
}
