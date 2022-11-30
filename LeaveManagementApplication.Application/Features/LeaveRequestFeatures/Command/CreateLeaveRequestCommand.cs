using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementApplication.Application.Features.LeaveRequestFeatures.Command
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public LeaveTypeViewModel leaveType { get; private set; }
        public int leaveTypeId { get; private set; }
        public DateTime dateRequested { get; private set; }
        public string requestComments { get; private set; }
        public DateTime? dateActioned { get; private set; }
        public bool approved { get; private set; }
        public bool cancelled { get; private set; }

    }

    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {

        private IMapper _mapper;
        private ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestCommandHandler(IMapper mapper , ILeaveRequestRepository leaveRequestRepository)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
        }


        public Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {


            
        }
    }


}
