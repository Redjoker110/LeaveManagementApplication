using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query;

public class GetLeaveAllocationListQuery : IRequest<List<LeaveTypeViewModel>>
{
}

public class GetLeaveTypeListQueryHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveTypeViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeListQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<List<LeaveTypeViewModel>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var leavetypes = await _leaveTypeRepository.GetLeaveTypesList();

            return _mapper.Map<List<LeaveTypeViewModel>>(leavetypes);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}