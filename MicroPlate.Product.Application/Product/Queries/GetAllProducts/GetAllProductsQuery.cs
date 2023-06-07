using MediatR;

namespace MicroPlate.Product.Application.Product.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<GetAllProductsDto>;

}
