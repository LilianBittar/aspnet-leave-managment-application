namespace HR.LeaveManagement.Application.Persistance.Contracts;

public interface ILeaveRequestRepository : IGeneticRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

    Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);

}
