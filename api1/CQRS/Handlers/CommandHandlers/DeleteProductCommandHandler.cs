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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private AppDbContext _context;
        public DeleteProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new DeleteProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
