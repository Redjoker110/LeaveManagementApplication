using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveType : AuditEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int defaultDay { get; set; }
}