using AutoMapper;
using LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Validators;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.Responses;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command;

public class CreateLeaveRequestCommand : IRequest<BAseCommandResponse>
{
    public DateTime startDate { get;set; }
    public DateTime endDate { get;set; }
    public LeaveTypeViewModel leaveType { get;set; }
    public int leaveTypeId { get;set; }
    public DateTime dateRequested { get;set; }
    public string requestComments { get;set; }
    public DateTime? dateActioned { get;set; }
    public bool approved { get;set; }
    public bool cancelled { get;set; }
    public LeaveRequestViewModel leaveRequestViewModel { get;set; }
}

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BAseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<BAseCommandResponse> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {

        var response = new BAseCommandResponse();
        var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
        var validatorResult = await validator.ValidateAsync(command.leaveRequestViewModel);

        if (validatorResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Error = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();

        }

        var leaveRequests = _mapper.Map<LeaveRequest>(command.leaveRequestViewModel);
        leaveRequests = await _leaveRequestRepository.Add(leaveRequests);
        
        response.Success = true;
        response.Message = "Creation Successful";
        response.id = leaveRequests.Id;
        return response;

    }
}