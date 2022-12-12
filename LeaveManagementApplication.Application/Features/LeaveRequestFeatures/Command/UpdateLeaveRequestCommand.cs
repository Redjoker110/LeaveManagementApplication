using LeaveManagementApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveRequest;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public int leaveTypeId { get; private set; }
        public string requestComments { get; private set; }
        
        public bool approved { get; private set; }
        public bool cancelled { get; private set; }
        public LeaveRequestViewModel leaveRequestViewModel { get; private set; }
        public ChangeLeaveRequestApprovalViewModel changeLeaveRequestApprovalViewModel { get; private set}

    }

    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly  IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandHandler(IMapper mapper , ILeaveRequestRepository leaveRequestRepository)
        { 
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand command, CancellationToken cancellationToken)
        {
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
