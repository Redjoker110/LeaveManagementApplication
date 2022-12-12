using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public LeaveTypeViewModel leaveType { get; private set; }
    public int leaveTypeId { get; private set; }
    public DateTime dateRequested { get; private set; }
    public string requestComments { get; private set; }
    public DateTime? dateActioned { get; private set; }
    public bool approved { get; private set; }
    public bool cancelled { get; private set; }
    public LeaveRequestViewModel leaveRequestViewModel { get; private set; }
}

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }


    public async Task<int> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaveRequests = _mapper.Map<LeaveRequest>(command.leaveRequestViewModel);
        leaveRequests = await _leaveRequestRepository.Add(leaveRequests);
        return leaveRequests.Id;
    }
}