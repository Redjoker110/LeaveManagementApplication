using LeaveManagementApplication.Application.ViewModels.Common;
using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.ViewModels.LeaveAllocation;

public class LeaveAllocationViewModel : BaseViewModel
{
    public int numberOfDays { get; private set; }
    public LeaveTypeViewModel leaveType { get; private set; }
    public int leaveTypeId { get; private set; }
    public int period { get; private set; }
}