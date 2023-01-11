using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;

namespace LeaveManagementApplication.Application.Features.LeaveAllocationFeatures.Validators
{
    public class UpdateLeaveAllocationValidator:AbstractValidator<LeaveAllocationViewModel>
    {
        public UpdateLeaveAllocationValidator()
        {
            Include(new CreateLeaveAllocationValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} must ne present");


        }

    }
}
