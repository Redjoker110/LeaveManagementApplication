using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveRequest : AuditEntity<int>
{
    public int Id { get; private set; }
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public LeaveType leaveType { get; private set; }
    public int leaveTypeId { get; private set; }
    public DateTime dateRequested { get; private set; }
    public string requestComments { get; private set; }
    public DateTime? dateActioned { get; private set; }
    public bool approved { get; private set; }
    public bool cancelled { get; private set; }
}