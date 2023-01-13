using LeaveManagementApplication.Application.ViewModels.Common;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.ViewModels.LeaveRequest;


public interface ILeaveRequestViewModel
{

    public DateTime startDate { get;  set; }
    public DateTime endDate { get;  set; }
    public LeaveTypeViewModel leaveType { get;  set; }
    public int leaveTypeId { get; set; }
    public DateTime dateRequested { get; set; }
    public string requestComments { get; set; }
    public DateTime? dateActioned { get; set; }
    public bool approved { get; set; }
    public bool cancelled { get; set; }

}
public class LeaveRequestViewModel : BaseViewModel , ILeaveRequestViewModel
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public LeaveTypeViewModel leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public DateTime dateRequested { get; set; }
    public string requestComments { get; set; }
    public DateTime? dateActioned { get; set; }
    public bool approved { get; set; }
    public bool cancelled { get; set; }
}