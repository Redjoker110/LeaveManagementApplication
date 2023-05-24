using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public int leaveTypeId { get; set; }
    public string requestComments { get; set; }

    public bool approved { get; set; }
    public bool cancelled { get; set; }
    public LeaveRequestViewModel leaveRequestViewModel { get; set; }
    public ChangeLeaveRequestApprovalViewModel changeLeaveRequestApprovalViewModel { get; set; }
}

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}