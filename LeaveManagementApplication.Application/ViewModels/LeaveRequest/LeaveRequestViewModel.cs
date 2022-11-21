using LeaveManagementApplication.Application.ViewModels.Common;
using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.ViewModels.LeaveRequest;

public class LeaveRequestViewModel : BaseViewModel
{
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public LeaveTypeViewModel leaveType { get; private set; }
    public int leaveTypeId { get; private set; }
    public DateTime dateRequested { get; private set; }
    public string requestComments { get; private set; }
    public DateTime? dateActioned { get; private set; }
    public bool approved { get; private set; }
    public bool cancelled { get; private set; }
}