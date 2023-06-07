using MediatR;

namespace MicroPlate.Product.Application.Product.Commands.DeleteProduct
{
    public record DeleteProductCommand : IRequest<bool>
    {
        public long ID { get; init; }
    }

}
