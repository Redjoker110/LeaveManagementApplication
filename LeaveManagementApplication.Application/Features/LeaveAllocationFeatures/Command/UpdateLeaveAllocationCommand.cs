using AutoMapper;
using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int id { get; set; }
    public int numberOfDays { get; private set; }
    public int leaveTypeId { get; private set; }
    public int period { get; private set; }
    public LeaveAllocationViewModel leaveAllocationViewModel { get; private set; }
}

public class UpdateLeaveAllocationCommandHandler  : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{

    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }


    public async Task<Unit> Handle( UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var leaveAllocation = _leaveAllocationRepository.Get(command.leaveAllocationViewModel.Id);
        await _mapper.Map(command.leaveAllocationViewModel, leaveAllocation);
        await _leaveAllocationRepository.update(leaveAllocation.Result);
        return Unit.Value;
    }
}
