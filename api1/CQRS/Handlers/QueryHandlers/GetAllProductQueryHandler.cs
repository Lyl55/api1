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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private AppDbContext _context;

        public GetAllProductQueryHandler(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request,
            CancellationToken cancellationToken)
        {
            return this._context.Products.Select(product => new GetAllProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }
    }
}
