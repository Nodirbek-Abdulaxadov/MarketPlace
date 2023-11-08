using Market.Models;

namespace Market.Data.Interfaces;

public interface IProductCategoryInterface
{
    Task<List<ProductCategory>> GetAllAsync();
    Task<ProductCategory> GetByIdAsync(int id);
    Task<ProductCategory> AddAsync(ProductCategory person);
    Task UpdateAsync(ProductCategory person);
    Task DeleteAsync(int id);
}