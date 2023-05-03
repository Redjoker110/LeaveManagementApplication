using AutoMapper;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command;

public class DeleteLeaveRequestCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    private readonly IMapper _mapper;

    public DeleteLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task Handle(DeleteLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.Get(command.Id);


        if (leaveRequest == null) throw new NotFoundException(nameof(LeaveRequest), command.Id);
        await _leaveRequestRepository.delete(leaveRequest);
    }
}