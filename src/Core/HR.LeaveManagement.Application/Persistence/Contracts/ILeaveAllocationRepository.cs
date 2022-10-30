namespace HR.LeaveManagement.Application.Persistance.Contracts;

public interface ILeaveAllocationRepository : IGeneticRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
}
