using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>,  ILeaveAllocationRepository
{
    
    private readonly LeaveManagementDbContext dbContext;

     public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task AddAllocations(List<LeaveAllocation> allocations)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await dbContext.LeaveAllocations
        .Include(q => q.LeaveType)
        .FirstOrDefaultAsync(q => q.Id == id);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocations = await dbContext.LeaveAllocations
        .Include(q => q.LeaveType)
        .ToListAsync();
        return leaveAllocations;
    }

    public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        throw new NotImplementedException();
    }
}
