namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Request.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
