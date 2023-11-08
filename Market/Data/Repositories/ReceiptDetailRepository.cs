using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class ReceiptDetailRepository : IReceiptDetailInterface
{
    private readonly MarketDbContext _dbContext;

    public ReceiptDetailRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReceiptDetail>> GetAllAsync()
        => await _dbContext.ReceiptDetails.ToListAsync();

    public async Task<ReceiptDetail> GetByIdAsync(int id)
        => await _dbContext.ReceiptDetails
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new ReceiptDetail();

    public async Task<ReceiptDetail> AddAsync(ReceiptDetail receiptDetail)
    {
        await _dbContext.ReceiptDetails.AddAsync(receiptDetail);
        await _dbContext.SaveChangesAsync();
        return receiptDetail;
    }

    public async Task UpdateAsync(ReceiptDetail receiptDetail)
    {
        _dbContext.ReceiptDetails.Update(receiptDetail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var receiptDetail = await GetByIdAsync(id);
        _dbContext.ReceiptDetails.Remove(receiptDetail);
        await _dbContext.SaveChangesAsync();
    }
}
