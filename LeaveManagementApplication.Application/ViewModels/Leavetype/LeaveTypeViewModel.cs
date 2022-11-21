using LeaveManagementApplication.Application.ViewModels.Common;

namespace LeaveManagementApplication.Application.ViewModels;

public class LeaveTypeViewModel : BaseViewModel
{
    public string Name { get; private set; }
    public int defaultDay { get; private set; }
}