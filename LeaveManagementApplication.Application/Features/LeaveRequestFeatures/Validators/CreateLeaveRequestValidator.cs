using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Validators
{
    public class CreateLeaveRequestValidator:AbstractValidator<ILeaveRequestViewModel>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
          

            RuleFor(sd => sd.startDate)
                .NotNull().WithMessage("{PropertyName} start date cannot be null")
                .NotEmpty().WithMessage("{PropertyName} start date cannot be empty")
                .LessThan(sd => sd.endDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(ed => ed.endDate)
                .NotNull().WithMessage("{PropertyName} end date cannot be null")
                .NotEmpty().WithMessage("{PropertyName} end date cannot be empty")
                .GreaterThan(ed=>ed.startDate).WithMessage("{PropertyName} must be after {ComparisionValue}");


            RuleFor(lt => lt.leaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await leaveTypeRepository.Exists(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName} does not exist");


            //RuleFor(dr => dr.dateRequested)
            //    .NotNull().WithMessage("{PropertyName} end date cannot be null")
            //    .NotEmpty().WithMessage("{PropertyName} end date cannot be empty");



            //RuleFor(da => da.dateActioned)
            //    .NotNull().WithMessage("{PropertyName} date actioned cannot be null")
            //    .NotEmpty().WithMessage("{PropertyName} date actioned cannot be empty");

            //RuleFor(a => a.approved)
            //    .NotNull().WithMessage("{PropertyName} cannot be null ")
            //    .NotEmpty().WithMessage("{PropertyName} cannot be empty");


            //RuleFor(c => c.cancelled)
            //    .NotNull().WithMessage("{PropertyName} cannot be null ")
            //    .NotEmpty().WithMessage("{PropertyName} cannot be empty");


            //RuleFor(rc => rc.requestComments)
            //    .NotNull().WithMessage("{PropertyName} cannot be null ")
            //    .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        }

    }
}
