
namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {

        public int Id {get; set;}
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }

        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto  { get; set; }
    }
