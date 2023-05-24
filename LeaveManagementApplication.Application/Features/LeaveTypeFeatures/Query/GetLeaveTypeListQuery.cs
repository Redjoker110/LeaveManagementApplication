using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.Services;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query;

public class GetLeaveTypeListQuery : IRequest<List<LeaveTypeViewModel>>
{
}

public class GetLeaveTypeListQueryHandler : IRequestHandler<GetLeaveTypeListQuery, List<LeaveTypeViewModel>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILoggingService<GetLeaveTypeListQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetLeaveTypeListQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
        ILoggingService<GetLeaveTypeListQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }


    public async Task<List<LeaveTypeViewModel>> Handle(GetLeaveTypeListQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            var data = _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);

            if (leaveTypes.Count == 1)
            {
                _logger.LogInformation("Leave types were successfully retrieved");
                return data;
            }

            if (leaveTypes.Count == 0) _logger.LogWarnings("Leave types were not retrieved ");

            if (leaveTypes == null) return null;

            return data;
        }
        catch (NotImplementedException e)
        {
            throw new NotImplementedException();
        }
    }
}