using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class ReceiptRepository : IReceiptInterface
{
    private readonly MarketDbContext _dbContext;

    public ReceiptRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Receipt>> GetAllAsync()
        => await _dbContext.Receipts.ToListAsync();

    public async Task<Receipt> GetByIdAsync(int id)
        => await _dbContext.Receipts
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new Receipt();

    public async Task<Receipt> AddAsync(Receipt receipt)
    {
        await _dbContext.Receipts.AddAsync(receipt);
        await _dbContext.SaveChangesAsync();
        return receipt;
    }

    public async Task UpdateAsync(Receipt receipt)
    {
        _dbContext.Receipts.Update(receipt);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Receipt = await GetByIdAsync(id);
        _dbContext.Receipts.Remove(Receipt);
        await _dbContext.SaveChangesAsync();
    }
}