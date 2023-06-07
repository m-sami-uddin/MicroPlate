using AutoMapper;
using MediatR;
using MicroPlate.Product.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroPlate.Product.Application.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            if (await _context.Product.FirstOrDefaultAsync(x => x.ID == request.ID) is Domain.Entities.Product product)
            {
                return _mapper.Map<GetProductDto>(product);
            }
            return null;

        }
    }
}
