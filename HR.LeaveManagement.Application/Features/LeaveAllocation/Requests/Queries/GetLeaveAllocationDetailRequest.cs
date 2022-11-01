using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Request.Queries;


public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}
