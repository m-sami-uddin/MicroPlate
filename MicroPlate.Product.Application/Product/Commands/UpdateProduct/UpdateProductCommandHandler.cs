using AutoMapper;
using MediatR;
using MicroPlate.Product.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroPlate.Product.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (await _context.Product.FirstOrDefaultAsync(x => x.ID == command.ID) is Domain.Entities.Product product)
            {
                _mapper.Map(command, product);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            return false;
        }

    }
}
