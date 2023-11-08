using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryInterface
{
    private readonly MarketDbContext _dbContext;

    public ProductCategoryRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductCategory>> GetAllAsync()
        => await _dbContext.ProductCategories.ToListAsync();

    public async Task<ProductCategory> GetByIdAsync(int id)
        => await _dbContext.ProductCategories
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new ProductCategory();

    public async Task<ProductCategory> AddAsync(ProductCategory person)
    {
        await _dbContext.ProductCategories.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }

    public async Task UpdateAsync(ProductCategory person)
    {
        _dbContext.ProductCategories.Update(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var person = await GetByIdAsync(id);
        _dbContext.ProductCategories.Remove(person);
        await _dbContext.SaveChangesAsync();
    }
}