using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command
{
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
       
        public int Id { get; set; }
        public string Name { get; private set; }
        public int defaultDay { get; private set; }
        public LeaveTypeViewModel leaveTypeViewModel { get; set; }

    }

    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository )
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            
        }


        public async Task<Unit> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leaveType = _leaveTypeRepository.Get(command.leaveTypeViewModel.Id);
            await _mapper.Map(command.leaveTypeViewModel, leaveType);
            await _leaveTypeRepository.update(leaveType.Result);
            return Unit.Value;



        }
    }


}
