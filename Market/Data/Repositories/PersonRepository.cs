using Market.Data.Interfaces;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class PersonRepository : IPersonInterface
{
    private readonly MarketDbContext _dbContext;

    public PersonRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Person>> GetAllAsync()
        => await _dbContext.Persons.ToListAsync();

    public async Task<Person> GetByIdAsync(int id)
        => await _dbContext.Persons
        .FirstOrDefaultAsync(i => i.Id == id)
        ?? new Person();

    public async Task<Person> AddAsync(Person person)
    {
        await _dbContext.Persons.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }

    public async Task UpdateAsync(Person person)
    {
        _dbContext.Persons.Update(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var person = await GetByIdAsync(id);
        _dbContext.Persons.Remove(person);
        await _dbContext.SaveChangesAsync();
    }
}