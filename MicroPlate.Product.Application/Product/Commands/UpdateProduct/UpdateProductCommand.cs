using MediatR;

namespace MicroPlate.Product.Application.Product.Commands.UpdateProduct
{
    public record UpdateProductCommand : IRequest<bool>
    {
        public long ID { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Barcode { get; init; } = string.Empty;
        public Int16 BuyingPrice { get; init; }
        public Int16 Rate { get; init; }
    }
}
