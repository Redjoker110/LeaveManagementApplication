using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;

public class DeleteLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task Handle(DeleteLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}