using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class CustomerRepository : ICustomerInterface
{
    private readonly MarketDbContext _dbContext;

    public CustomerRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> GetAllAsync()
        => await _dbContext.Customers.ToListAsync();

    public async Task<Customer> GetByIdAsync(int id)
        => await _dbContext.Customers
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new Customer();

    public async Task<Customer> AddAsync(Customer Customer)
    {
        await _dbContext.Customers.AddAsync(Customer);
        await _dbContext.SaveChangesAsync();
        return Customer;
    }

    public async Task UpdateAsync(Customer Customer)
    {
        _dbContext.Customers.Update(Customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Customer = await GetByIdAsync(id);
        _dbContext.Customers.Remove(Customer);
        await _dbContext.SaveChangesAsync();
    }
}