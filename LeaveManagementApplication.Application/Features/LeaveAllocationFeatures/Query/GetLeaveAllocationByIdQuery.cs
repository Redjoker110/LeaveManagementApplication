﻿using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Query;

public class GetLeaveAllocationByIdQuery : IRequest<LeaveAllocationViewModel>
{
    public int Id { get; set; }
}

public class GetLeaveAllocationByIdQueryHandler : IRequestHandler<GetLeaveAllocationByIdQuery, LeaveAllocationViewModel>
{
    private readonly ILeaveManagementDbContext _context;

    public GetLeaveAllocationByIdQueryHandler(ILeaveManagementDbContext context)

    {
        _context = context;
    }


    //public async  Task<LeaveAllocationViewModel> Handle(GetLeaveAllocationByIdQuery query, CancellationToken cancellationToken)
    //{
    //    var leaveAllocationInformation = await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.Id == query.Id);
    //    if (leaveAllocationInformation == null) return  null;
    //    throw NotImplementedException;
    //}
    public Task<LeaveAllocationViewModel> Handle(GetLeaveAllocationByIdQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}