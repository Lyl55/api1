using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api1.CQRS.Queries.Request;
using api1.CQRS.Queries.Response;
using api1.DB;
using MediatR;

namespace api1.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByProductIdQueryRequest, GetByProductIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetByIdProductQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetByProductIdQueryResponse> Handle(GetByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            return new GetByProductIdQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
