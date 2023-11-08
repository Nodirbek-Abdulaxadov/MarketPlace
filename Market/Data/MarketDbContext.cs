using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data;

public class MarketDbContext : DbContext
{
    public MarketDbContext(DbContextOptions<MarketDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptDetail> ReceiptDetails { get; set;}
}