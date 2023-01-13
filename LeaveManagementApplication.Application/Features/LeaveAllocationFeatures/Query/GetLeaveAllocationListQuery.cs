using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Query;

public class GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationViewModel>>
{
}

public class GetLeaveAllocationListQueryHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public GetLeaveAllocationListQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }


    public async Task<List<LeaveAllocationViewModel>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsList();

            return _mapper.Map<List<LeaveAllocationViewModel>>(leaveAllocations);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}