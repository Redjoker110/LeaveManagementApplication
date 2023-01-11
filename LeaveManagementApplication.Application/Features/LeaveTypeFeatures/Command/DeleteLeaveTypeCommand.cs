using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Exceptions;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Domain.Models;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command
{
    public class DeleteLeaveTypeCommand:IRequest
    { 
        public int Id { get; set; }

    }

    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(command.Id);

            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), command.Id);
            }

            await _leaveTypeRepository.delete(leaveType);
            return Unit.Value;
        }
    }
}
