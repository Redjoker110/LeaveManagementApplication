using LeaveManagementApplication.Application.ViewModels.Common;

namespace LeaveManagementApplication.Application.ViewModels.Leavetype;

public interface ILeaveTypeViewModel
{
    public string Name { get; set; }
    public int defaultDay { get; set; }
}

public class LeaveTypeViewModel : BaseViewModel, ILeaveTypeViewModel
{
    public string Name { get; set; }
    public int defaultDay { get; set; }
}