namespace LeaveManagementApplication.Application.IRepositories
{
    public interface IGenericRepository<T> where T : class

    {

        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T id);
        Task update(T entity);
        Task delete(T entity);
        Task<bool> Exists(int id);

    }

   
}
