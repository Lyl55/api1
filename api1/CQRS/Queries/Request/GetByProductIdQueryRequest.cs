using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.CQRS.Queries.Response;
using MediatR;

namespace api1.CQRS.Queries.Request
{
    public class GetByProductIdQueryRequest : IRequest<GetByProductIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
