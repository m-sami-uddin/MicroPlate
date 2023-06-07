using AutoMapper;
using MediatR;
using MicroPlate.Product.Application.Common.Interfaces;

namespace MicroPlate.Product.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<CreateProductCommand, Domain.Entities.Product>(request);
            _context.Product.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return (product.ID);
        }
    }
}
