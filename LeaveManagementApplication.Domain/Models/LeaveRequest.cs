using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveRequest : AuditEntity<int>
{
    public int Id { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public LeaveType leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public DateTime dateRequested { get; set; }
    public string requestComments { get; set; }
    public DateTime? dateActioned { get; set; }
    public bool approved { get; set; }
    public bool cancelled { get; set; }
}