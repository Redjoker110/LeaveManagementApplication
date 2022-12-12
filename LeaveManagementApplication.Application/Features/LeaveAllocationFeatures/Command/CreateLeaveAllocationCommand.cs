using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int numberOfDays { get; private set; }
    public LeaveTypeViewModel leaveType { get; private set; }
    public int leaveTypeId { get; private set; }
    public int period { get; private set; }
    public LeaveAllocationViewModel leaveAllocationViewModel { get; private set; }
}

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand command ,CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveAllocation>(command.leaveAllocationViewModel);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }


   
}