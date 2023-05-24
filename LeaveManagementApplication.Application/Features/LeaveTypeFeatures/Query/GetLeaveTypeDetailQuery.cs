using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.Services;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query;

public class GetLeaveTypeDetailQuery : IRequest<LeaveTypeViewModel>
{
    public int Id { get; set; }
}

public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeViewModel>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILoggingService<GetLeaveTypeDetailQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
        ILoggingService<GetLeaveTypeDetailQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }


    public async Task<LeaveTypeViewModel> Handle(GetLeaveTypeDetailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            var data = _mapper.Map<LeaveTypeViewModel>(leaveType);
            if (leaveType == null) return null;

            return data;
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}