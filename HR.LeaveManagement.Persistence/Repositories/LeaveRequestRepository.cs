using Microsoft.EntityFrameworkCore;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await dbContext.LeaveRequests
        .Include(p => p.LeaveType)
        .FirstOrDefaultAsync(q => q.Id == id);
        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        var leaveRequest = await dbContext.LeaveRequests
        .Include(p => p.LeaveType)
        .ToListAsync();
        return leaveRequest;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();

    }


}