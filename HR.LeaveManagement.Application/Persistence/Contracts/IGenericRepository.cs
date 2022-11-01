namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGeneticRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);

}
