using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;

public class UpdateLeaveTypeCommand : IRequest<int>
{
   public int Id { get; set; }
    public string Name { get; set; }
    public int defaultDay { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CreateUserId { get; set; } = "admin";
    public DateTime ModifyDate { get; set; }

    public string ModifyUserId { get; set; } = "admin";
    public bool IsActive { get; set; } = true;
    public int StatusId { get; set; }

}

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<int> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var leaveTypesToUpdate = _mapper.Map<LeaveType>(command);
        await _leaveTypeRepository.UpdateAsync(leaveTypesToUpdate);
        if (leaveTypesToUpdate == null) return default;
        return leaveTypesToUpdate.Id;

    }
}