using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class ProductRepository : IProductInterface
{
    private readonly MarketDbContext _dbContext;

    public ProductRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllAsync()
        => await _dbContext.Products.ToListAsync();

    public async Task<Product> GetByIdAsync(int id)
        => await _dbContext.Products
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new Product();

    public async Task<Product> AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Product = await GetByIdAsync(id);
        _dbContext.Products.Remove(Product);
        await _dbContext.SaveChangesAsync();
    }
}