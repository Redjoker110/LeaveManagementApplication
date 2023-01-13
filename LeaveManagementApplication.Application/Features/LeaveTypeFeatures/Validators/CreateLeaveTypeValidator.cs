using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Validators
{
    public class CreateLeaveTypeValidator:AbstractValidator<ILeaveTypeViewModel>
    {
        public CreateLeaveTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must  not exceed {ComparisonValue} characters");

            RuleFor(r => r.defaultDay)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }

    }
}
