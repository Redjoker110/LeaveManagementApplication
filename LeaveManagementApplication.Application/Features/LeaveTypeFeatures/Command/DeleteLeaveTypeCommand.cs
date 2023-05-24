using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;

public class DeleteLeaveTypeCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}