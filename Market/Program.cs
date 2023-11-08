using Market.Data;
using Market.Data.Interfaces;
using Market.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MarketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));

builder.Services.AddTransient<IProductInterface, ProductRepository>();
builder.Services.AddTransient<IProductCategoryInterface, ProductCategoryRepository>();
builder.Services.AddTransient<ICustomerInterface, CustomerRepository>();
builder.Services.AddTransient<IPersonInterface, PersonRepository>();
builder.Services.AddTransient<IReceiptInterface, ReceiptRepository>();
builder.Services.AddTransient<IReceiptDetailInterface, ReceiptDetailRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
