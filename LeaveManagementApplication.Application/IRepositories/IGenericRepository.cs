using LeaveManagementApplication.Domain.Common;

namespace LeaveManagementApplication.Application.IRepositories;

public interface IGenericRepository<T> where T : BaseEntity

{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> Exists(int id);
}