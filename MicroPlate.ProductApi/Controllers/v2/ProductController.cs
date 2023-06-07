using MediatR;
using MicroPlate.Product.Application.Product.Commands.CreateProduct;
using MicroPlate.Product.Application.Product.Commands.DeleteProduct;
using MicroPlate.Product.Application.Product.Commands.UpdateProduct;
using MicroPlate.Product.Application.Product.Queries.GetAllProducts;
using MicroPlate.Product.Application.Product.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace MicroPlate.ProductApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVErsion}/[controller]")]
    [ApiVersion("2.0")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IResult> Post(CreateProductCommand command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken) > 0
            ? Results.Ok("Added Successfully")
                : Results.BadRequest("Delete Failed");

        [HttpGet]
        public async Task<GetAllProductsDto> Get(CancellationToken cancellationToken) =>
            await _mediator.Send(new GetAllProductsQuery(), cancellationToken);

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id, CancellationToken cancellationToken) =>
            await _mediator.Send(new GetProductQuery { ID = id }, cancellationToken) is GetProductDto product
            ? Results.Ok(product)
                : Results.NotFound("Not Found");

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, CancellationToken cancellationToken) =>
            await _mediator.Send(new DeleteProductCommand { ID = id }, cancellationToken)
            ? Results.Ok("Deleted Successfully")
                : Results.BadRequest("Delete Failed");

        [HttpPut]
        public async Task<IResult> Update(UpdateProductCommand command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken)
                ? Results.Ok("Updated Successfully")
                    : Results.BadRequest("Update Failed");

    }
}
