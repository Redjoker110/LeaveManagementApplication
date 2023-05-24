using LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;
using LeaveManagementApplication.Domain.Models;

namespace LeaveManagementApplication.Application.Extensions;

public static class LeaveAllocationExtension
{
    public static LeaveAllocation ToEntity(this CreateLeaveAllocationCommand model)
    {
        return new LeaveAllocation();
    }
}