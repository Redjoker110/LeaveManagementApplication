using AutoMapper;
using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Validators;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;
using ValidationException = LeaveManagementApplication.Application.Exceptions.ValidationException;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command
{
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
       
        public int Id { get; set; }
        public string Name { get;set; }
        public int defaultDay { get;set; }
        public LeaveTypeViewModel leaveTypeViewModel { get; set; }

    }

    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository )
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            
        }


        public async Task<Unit> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
        {

            var valiadator = new UpdateLeaveTypeValidator();
            var validationResult = await valiadator.ValidateAsync(command.leaveTypeViewModel);

            if (validationResult.IsValid==false)
            {
                throw new ValidationException(validationResult);
            }

            var leaveType = _leaveTypeRepository.Get(command.leaveTypeViewModel.Id);
            await _mapper.Map(command.leaveTypeViewModel, leaveType);
            await _leaveTypeRepository.update(leaveType.Result);
            return Unit.Value;



        }
    }


}
