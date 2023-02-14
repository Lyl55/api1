using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.CQRS.Commands.Request;
using api1.CQRS.Commands.Response;
using api1.CQRS.Queries.Request;
using api1.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetByProductIdQueryRequest requestModel)
        {
            GetByProductIdQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest requestModel)
        {
            UpdateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}
