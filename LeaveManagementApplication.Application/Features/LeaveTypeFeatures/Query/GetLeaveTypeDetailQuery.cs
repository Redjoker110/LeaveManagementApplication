using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagementApplication.Application.Persistance.Contracts;
using LeaveManagementApplication.Application.ViewModels;
using MediatR;

namespace LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query
{
    public class GetLeaveRequestDetailQuery :IRequest<LeaveTypeViewModel>
    {
        public int Id { get; set; }

    }
    public class GetLeaveTypeDetailQueryHandler: IRequestHandler<GetLeaveRequestDetailQuery,LeaveTypeViewModel> 
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }


        public async  Task<LeaveTypeViewModel> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveType = await _leaveTypeRepository.GetLeaveTypeWithDetails(request.Id);

                return _mapper.Map<LeaveTypeViewModel>(leaveType);
            }
            catch (NotImplementedException e)
            {
                throw new NotImplementedException();
            }
        }
    }





}
