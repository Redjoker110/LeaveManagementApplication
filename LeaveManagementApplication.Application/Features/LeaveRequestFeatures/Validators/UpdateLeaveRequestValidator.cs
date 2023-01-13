using FluentValidation;
using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Validators
{
    public class UpdateLeaveRequestValidator: AbstractValidator<LeaveRequestViewModel>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)

        {

          _leaveTypeRepository = leaveTypeRepository;
           

            Include(new CreateLeaveRequestValidator(leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
