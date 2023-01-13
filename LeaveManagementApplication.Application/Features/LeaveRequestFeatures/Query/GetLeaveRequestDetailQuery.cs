using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Query;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestViewModel>
{
    public int Id { get; set; }
}

public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestViewModel>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestDetailQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }


    public async Task<LeaveRequestViewModel> Handle(GetLeaveRequestDetailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);

            return _mapper.Map<LeaveRequestViewModel>(leaveRequest);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}