using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api1.CQRS.Commands.Request;
using api1.CQRS.Commands.Response;
using api1.DB;
using MediatR;

namespace api1.CQRS.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private AppDbContext _context;
        public UpdateProductCommandHandler(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateProduct = this._context.Products.FirstOrDefault(p => p.Id == request.Id);
            updateProduct.Price = request.Price;
            updateProduct.Quantity = request.Quantity;
            updateProduct.Name = request.Name;
            await this._context.SaveChangesAsync();

            return new UpdateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = updateProduct.Id
            };
        }
    }
}
