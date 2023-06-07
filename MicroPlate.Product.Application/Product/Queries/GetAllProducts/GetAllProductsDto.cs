namespace MicroPlate.Product.Application.Product.Queries.GetAllProducts
{
    public record GetAllProductsDto
    {
        public List<Domain.Entities.Product> products { get; init; }
    }
}
