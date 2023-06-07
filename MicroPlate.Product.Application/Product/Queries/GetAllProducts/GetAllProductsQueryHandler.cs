using AutoMapper;
using MediatR;
using MicroPlate.Product.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroPlate.Product.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAllProductsDto?> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            return new GetAllProductsDto { products = await _context.Product.ToListAsync() };

        }
    }
}
