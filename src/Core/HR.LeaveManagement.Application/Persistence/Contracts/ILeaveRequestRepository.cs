using HR.LeaveManagement.Domain;
namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGeneticRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

    Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);

}
