using Market.Data;
using Market.Models;
using Market.Yangilik.Interfaces;

namespace Market.Yangilik.Repositories;

public class PersonRepository : Repository<Person>, IPersonInterface
{
    public PersonRepository(MarketDbContext dbContext) 
        : base(dbContext)
    {
    }
}