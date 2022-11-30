using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using LeaveManagementApplication.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {

        public int Id { get; set; }
        public string name { get; set; }
        public int deafultDays { get; set; }
        public LeaveTypeViewModel leaveTypeViewModel { get; set; }
    }
    public class CreateLeaveTypeCommandHanlder : IRequestHandler<CreateLeaveTypeCommand, int>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHanlder(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;

        }

        public async Task<int> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leavetypes = _mapper.Map<LeaveType>(command.leaveTypeViewModel);
            leavetypes = await _leaveTypeRepository.Add(leavetypes);
            return leavetypes.Id;


        }
    }
}





    
