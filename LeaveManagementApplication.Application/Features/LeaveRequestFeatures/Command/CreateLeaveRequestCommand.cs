using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.Responses;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command;

public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public LeaveTypeViewModel leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public DateTime dateRequested { get; set; }
    public string requestComments { get; set; }
    public DateTime? dateActioned { get; set; }
    public bool approved { get; set; }
    public bool cancelled { get; set; }
    public LeaveRequestViewModel leaveRequestViewModel { get; set; }
}

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}