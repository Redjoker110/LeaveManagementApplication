using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels.LeaveAllocation;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query
{
    public class GetLeaveAllocationDetailQuery :IRequest<LeaveAllocationViewModel>
    {
        public int Id { get; set; }

    }
    public class GetLeaveAllocationDetailQueryHandler: IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationViewModel> 
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public GetLeaveAllocationDetailQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }


        public async  Task<LeaveAllocationViewModel> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

                return _mapper.Map<LeaveAllocationViewModel>(leaveAllocation);
            }
            catch (NotImplementedException e)
            {
                throw new NotImplementedException();
            }
        }
    }





}
