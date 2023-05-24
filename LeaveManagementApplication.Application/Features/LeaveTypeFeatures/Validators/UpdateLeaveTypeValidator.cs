using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.Leavetype;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Validators;

public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeViewModel>
{
    public UpdateLeaveTypeValidator()

    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present");
    }
}