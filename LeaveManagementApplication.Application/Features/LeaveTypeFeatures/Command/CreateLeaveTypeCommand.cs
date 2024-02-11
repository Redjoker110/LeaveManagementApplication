using AutoMapper;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;

public class CreateLeaveTypeCommand : IRequest<int>
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

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;


    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        // convert to domain entity object
        var leaveTypesToCreate = _mapper.Map<LeaveType>(command);

        // add to database
        await _leaveTypeRepository.CreateAsync(leaveTypesToCreate);

        if (leaveTypesToCreate == null) return default;
        return leaveTypesToCreate.Id;
    }
}