using Market.Models;

namespace Market.Data.Interfaces;

public interface IReceiptInterface
{
    Task<List<Receipt>> GetAllAsync();
    Task<Receipt> GetByIdAsync(int id);
    Task<Receipt> AddAsync(Receipt person);
    Task UpdateAsync(Receipt person);
    Task DeleteAsync(int id);
}