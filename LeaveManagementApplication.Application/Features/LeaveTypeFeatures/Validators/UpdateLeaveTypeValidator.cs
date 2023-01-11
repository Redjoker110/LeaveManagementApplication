using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeaveManagementApplication.Application.ViewModels;

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
