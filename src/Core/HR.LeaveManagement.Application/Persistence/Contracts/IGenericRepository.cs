namespace HR.LeaveManagement.Application.Persistance.Contracts;

public interface IGeneticRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IRradOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);

}
