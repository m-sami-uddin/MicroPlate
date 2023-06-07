using MicroPlate.Product.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductModel = MicroPlate.Product.Domain.Entities.Product;

namespace MicroPlate.Product.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MicroPlate.Product");
        //Entry()
    }
    public DbSet<ProductModel> Product { get; set; }

}
