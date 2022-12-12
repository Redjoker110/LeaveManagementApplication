using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public int Id { get; set; }
    public string name { get; set; }
    public int deafultDays { get; set; }
    public LeaveTypeViewModel leaveTypeViewModel { get; set; }
}

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var leavetypes = _mapper.Map<LeaveType>(command.leaveTypeViewModel);
        leavetypes = await _leaveTypeRepository.Add(leavetypes);
        return leavetypes.Id;
    }
}