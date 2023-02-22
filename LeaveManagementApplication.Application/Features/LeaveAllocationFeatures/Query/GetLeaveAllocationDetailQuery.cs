using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Query;

public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationViewModel>
{
    public int Id { get; set; }
}

public class
    GetLeaveAllocationDetailQueryHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationViewModel>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }


    public async Task<LeaveAllocationViewModel> Handle(GetLeaveAllocationDetailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

            return _mapper.Map<LeaveAllocationViewModel>(leaveAllocation);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}