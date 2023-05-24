namespace LeaveManagementApplication.Application.ViewModels.Leavetype;

public interface ICreateLeaveTypeViewModel
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
    public string CreateUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ModifyUserId { get; set; }
    public DateTime ModifyDate { get; set; }
    public bool IsActive { get; set; }
    public int StatusId { get; set; }
}

public class CreateLeaveTypeViewModel : ICreateLeaveTypeViewModel
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
    public string CreateUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ModifyUserId { get; set; }
    public DateTime ModifyDate { get; set; }
    public bool IsActive { get; set; }
    public int StatusId { get; set; }
}