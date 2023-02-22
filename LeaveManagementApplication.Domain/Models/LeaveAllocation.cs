using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveAllocation : AuditEntity<int>
{
    public int Id { get; set; }
    public int numberOfDays { get; set; }
    public LeaveType leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public int period { get; set; }
}