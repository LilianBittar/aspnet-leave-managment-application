namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;

 public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
