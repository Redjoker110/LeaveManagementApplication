using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Query;

public class GetLeaveAllocationByIdQuery : IRequest<LeaveAllocationViewModel>
{
    public int Id { get; set; }
}

public class GetLeaveAllocationByIdQueryHandler : IRequestHandler<GetLeaveAllocationByIdQuery, LeaveAllocationViewModel>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationByIdQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }


    public async Task<LeaveAllocationViewModel> Handle(GetLeaveAllocationByIdQuery query,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}