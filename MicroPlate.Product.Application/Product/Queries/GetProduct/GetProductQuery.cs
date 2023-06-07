using MediatR;

namespace MicroPlate.Product.Application.Product.Queries.GetProduct
{
    public record GetProductQuery : IRequest<GetProductDto>
    {
        public long ID { get; set; }
    }
}
