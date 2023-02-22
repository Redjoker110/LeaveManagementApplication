using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Validators;

public class UpdateLeaveAllocationValidator : AbstractValidator<LeaveAllocationViewModel>
{
    public UpdateLeaveAllocationValidator()
    {
        Include(new CreateLeaveAllocationValidator());

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present");
    }
}