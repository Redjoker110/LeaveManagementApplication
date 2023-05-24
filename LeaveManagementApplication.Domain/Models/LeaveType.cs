using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Domain.Models;

public class LeaveType : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int defaultDay { get; set; }
    public string CreateUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ModifyUserId { get; set; }
    public DateTime ModifyDate { get; set; }
    public bool IsActive { get; set; }
    public int StatusId { get; set; }
}
