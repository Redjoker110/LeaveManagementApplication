using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int numberOfDays { get; set; }
    public LeaveTypeViewModel leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public int period { get; set; }
    public LeaveAllocationViewModel leaveAllocationViewModel { get; set; }
}

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}