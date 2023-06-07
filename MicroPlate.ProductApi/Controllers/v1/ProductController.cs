using MediatR;
using MicroPlate.Product.Application.Product.Commands.CreateProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroPlate.ProductApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVErsion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<long> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }


    }

}
