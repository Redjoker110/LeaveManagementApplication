using AutoMapper;
using LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Command;
using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Validators;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.Responses;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;

public class CreateLeaveTypeCommand : IRequest<BAseCommandResponse> 
{
    public int Id { get; set; }
    public string name { get; set; }
    public int deafultDays { get; set; }
    public LeaveTypeViewModel leaveTypeViewModel { get; set; }
}

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BAseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<BAseCommandResponse> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var response = new BAseCommandResponse();
        var validator = new CreateLeaveTypeValidator();
        var validationResult = await validator.ValidateAsync(command.leaveTypeViewModel);

        if (validationResult.IsValid == false)

        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        var leavetypes = _mapper.Map<LeaveType>(command.leaveTypeViewModel);
        leavetypes = await _leaveTypeRepository.Add(leavetypes);

        response.Success = true;
        response.Message = "Creation Successful";
        response.id = leavetypes.Id;
        return response;
    }
}