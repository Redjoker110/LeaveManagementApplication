using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Validators
{
    public class CreateLeaveAllocationValidator:AbstractValidator<ILeaveAllocationViewModel>
    {
        public CreateLeaveAllocationValidator()
        {

            RuleFor(nd => nd.numberOfDays)
                .LessThan(1).WithMessage("{PropertyName} cannot be less than 1 ")
                .GreaterThan(50).WithMessage("{PropertyName} cannot exceed 50")
                .NotNull().WithMessage("{PropertyName} cannot be null ")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(p => p.period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

        }
        

    }
}
