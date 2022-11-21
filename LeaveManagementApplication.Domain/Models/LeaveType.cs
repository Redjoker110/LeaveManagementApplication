using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveType : AuditEntity<int>
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int defaultDay { get; private set; }
}