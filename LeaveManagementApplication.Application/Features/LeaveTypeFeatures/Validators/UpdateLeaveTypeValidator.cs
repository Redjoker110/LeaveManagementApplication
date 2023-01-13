using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Validators
{
    public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeViewModel>
    {

        public UpdateLeaveTypeValidator()

        {
            Include(new CreateLeaveTypeValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
