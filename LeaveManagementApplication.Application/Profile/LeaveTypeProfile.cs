using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;
using LeaveManagementApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.Profile
{
    public class LeaveTypeProfile:AutoMapper.Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeViewModel, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeViewModel>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
            CreateMap<DeleteLeaveTypeCommand, LeaveType>();
        }
    }
}
