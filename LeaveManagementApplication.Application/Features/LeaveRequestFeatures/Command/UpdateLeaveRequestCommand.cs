using LeaveManagementApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Validators;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime startDate { get;set; }
        public DateTime endDate { get;set; }
        public int leaveTypeId { get;set; }
        public string requestComments { get;set; }
        
        public bool approved { get;set; }
        public bool cancelled { get;set; }
        public LeaveRequestViewModel leaveRequestViewModel { get;  set; }
        public ChangeLeaveRequestApprovalViewModel changeLeaveRequestApprovalViewModel { get; set; }

    }

    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly  IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(IMapper mapper , ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
        { 
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(command.leaveRequestViewModel);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }

            var leaveRequest = _leaveRequestRepository.Get(command.leaveRequestViewModel.Id);

            if (command.leaveRequestViewModel != null)
            {
                
                await _mapper.Map(command.leaveRequestViewModel, leaveRequest);
                await _leaveRequestRepository.update(leaveRequest.Result);

            }
            else if(command.changeLeaveRequestApprovalViewModel != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest.Result , command.changeLeaveRequestApprovalViewModel.Approved);
            }

            return Unit.Value;


        }
    }



}
