using Market.Data;
using Market.Models;
using Market.Yangilik.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Yangilik.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly MarketDbContext _dbContext;

    public Repository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
        => await _dbContext.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>()
                .FirstOrDefaultAsync(t => t.Id == id);

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}