using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Application.ViewModels.Common;

namespace LeaveManagementApplication.Application.ViewModels.LeaveRequest
{
    public class ChangeLeaveRequestApprovalViewModel: BaseViewModel
    {
        public bool? Approved { get; set; }

    }
}
