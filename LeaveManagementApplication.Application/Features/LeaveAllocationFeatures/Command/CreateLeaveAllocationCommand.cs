using AutoMapper;
using LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Validators;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int numberOfDays { get;set; }
    public LeaveTypeViewModel leaveType { get;set; }
    public int leaveTypeId { get;set; }
    public int period { get;set; }
    public LeaveAllocationViewModel leaveAllocationViewModel { get;set; }
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
        var validator = new CreateLeaveAllocationValidator();
        var valiatorResult = await validator.ValidateAsync(command.leaveAllocationViewModel);

        if (valiatorResult.IsValid == false)
        {
            throw new Exception();

        }

        var leaveAllocation = _mapper.Map<LeaveAllocation>(command.leaveAllocationViewModel);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }


   
}