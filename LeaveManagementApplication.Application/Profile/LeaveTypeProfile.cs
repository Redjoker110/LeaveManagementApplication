using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.Profile;

public class LeaveTypeProfile : AutoMapper.Profile
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