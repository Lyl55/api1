using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api1.CQRS.Commands.Request;
using api1.CQRS.Commands.Response;
using api1.DB;
using api1.Models.ProductModels;
using MediatR;

namespace api1.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private AppDbContext _context;

        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new ProductModel()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
