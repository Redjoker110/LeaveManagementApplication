using LeaveManagementApplication.Application.IRepositories;
using LeaveManagementApplication.Domain.Common;
using LeaveManagementApplication.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementApplication.Persistence.Repositries;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly LeaveManagementDbContext _context;


    public GenericRepository(LeaveManagementDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    Task IGenericRepository<T>.CreateAsync(T entity)
    {
        return CreateAsync(entity);
    }


    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetByIdAsync(id);
        return entity != null;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}