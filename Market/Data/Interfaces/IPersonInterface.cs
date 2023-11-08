using Market.Models;

namespace Market.Data.Interfaces;

public interface IPersonInterface
{
    Task<List<Person>> GetAllAsync();
    Task<Person> GetByIdAsync(int id);
    Task<Person> AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(int id);
}