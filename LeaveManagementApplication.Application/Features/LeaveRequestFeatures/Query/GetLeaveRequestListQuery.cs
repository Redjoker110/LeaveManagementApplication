using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Query;

public class GetLeaveAllocationListQuery : IRequest<List<LeaveRequestViewModel>>
{
}

public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveRequestViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestListQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }


    public async Task<List<LeaveRequestViewModel>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsList();

            return _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}