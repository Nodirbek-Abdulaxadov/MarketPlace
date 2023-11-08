using Market.Models;

namespace Market.Data.Interfaces;

public interface IReceiptDetailInterface
{
    Task<List<ReceiptDetail>> GetAllAsync();
    Task<ReceiptDetail> GetByIdAsync(int id);
    Task<ReceiptDetail> AddAsync(ReceiptDetail person);
    Task UpdateAsync(ReceiptDetail person);
    Task DeleteAsync(int id);
}