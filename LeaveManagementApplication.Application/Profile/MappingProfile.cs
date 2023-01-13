using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.Profile;

public class MappingProfile : AutoMapper.Profile

{
    public MappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap(); 
        CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeViewModel >().ReverseMap();
    }

}