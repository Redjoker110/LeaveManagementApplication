using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query;

public class GetLeaveRequestDetailQuery : IRequest<LeaveTypeViewModel>
{
    public int Id { get; set; }
}

public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveTypeViewModel>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<LeaveTypeViewModel> Handle(GetLeaveRequestDetailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var leaveType = await _leaveTypeRepository.GetLeaveTypeWithDetails(request.Id);

            return _mapper.Map<LeaveTypeViewModel>(leaveType);
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}