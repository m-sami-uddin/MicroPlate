using MediatR;

namespace MicroPlate.Product.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public Int16 BuyingPrice { get; set; }
        public Int16 Rate { get; set; }
    }
}
