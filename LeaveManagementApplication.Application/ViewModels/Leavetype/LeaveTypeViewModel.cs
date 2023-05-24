using LeaveManagementApplication.Application.ViewModels.Common;

namespace LeaveManagementApplication.Application.ViewModels.Leavetype;

public interface ILeaveTypeViewModel
{
    public string Name { get; set; }
    public int defaultDay { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CreateUserId { get; set; }
    public DateTime ModifyDate { get; set; }

    public string ModifyUserId { get; set; }
    public bool IsActive { get; set; } 
    public int StatusId { get; set; }

}

public class LeaveTypeViewModel : BaseViewModel, ILeaveTypeViewModel
{
    public string Name { get; set; }
    public int defaultDay { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreateUserId { get; set; }
    public DateTime ModifyDate { get; set; }
    public string ModifyUserId { get; set; }
    public bool IsActive { get; set; }
    public int StatusId { get; set; }
}