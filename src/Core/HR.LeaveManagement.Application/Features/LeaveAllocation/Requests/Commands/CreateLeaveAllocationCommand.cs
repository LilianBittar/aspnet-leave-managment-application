namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;

 public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }