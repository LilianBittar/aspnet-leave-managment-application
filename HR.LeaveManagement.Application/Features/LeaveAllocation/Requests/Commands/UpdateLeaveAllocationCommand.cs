
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {

        public int Id {get; set;}
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }

    
    }
