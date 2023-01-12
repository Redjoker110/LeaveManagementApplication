using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistance.Repositiries
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

    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;


        public GenericRepository(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();

        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
         
            
        }

        public async Task delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }
    }
}
