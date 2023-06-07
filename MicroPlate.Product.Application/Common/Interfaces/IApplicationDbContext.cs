using Microsoft.EntityFrameworkCore;
using ProductModel = MicroPlate.Product.Domain.Entities.Product;
namespace MicroPlate.Product.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    DbSet<ProductModel> Product { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    //  EntityEntry<TEntity> Entry<TEntity>(TEntity entity)

}

