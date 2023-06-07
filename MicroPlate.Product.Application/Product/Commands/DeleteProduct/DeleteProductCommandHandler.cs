using AutoMapper;
using MediatR;
using MicroPlate.Product.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroPlate.Product.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            if (await _context.Product.FirstOrDefaultAsync(x => x.ID == command.ID) is Domain.Entities.Product product)
            {
                _context.Product.Remove(product);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            return false;

        }
    }
}
