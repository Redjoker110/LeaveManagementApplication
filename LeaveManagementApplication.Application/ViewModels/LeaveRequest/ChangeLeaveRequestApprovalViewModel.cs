using LeaveManagementApplication.Application.ViewModels.Common;

namespace LeaveManagementApplication.Application.ViewModels.LeaveRequest;

public class ChangeLeaveRequestApprovalViewModel : BaseViewModel
{
    public bool? Approved { get; set; }
}