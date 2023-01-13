using LeaveManagementApplication.Application.ViewModels.Common;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.ViewModels.LeaveAllocation;

public interface ILeaveAllocationViewModel
{
    public int numberOfDays { get;  set; }
    public LeaveTypeViewModel leaveType { get;  set; }
    public int leaveTypeId { get;  set; }
    public int period { get;  set; }

}

public class LeaveAllocationViewModel : BaseViewModel, ILeaveAllocationViewModel
{
    public int numberOfDays { get;  set; }
    public LeaveTypeViewModel leaveType { get;  set; }
    public int leaveTypeId { get;  set; }
    public int period { get;  set; }
}