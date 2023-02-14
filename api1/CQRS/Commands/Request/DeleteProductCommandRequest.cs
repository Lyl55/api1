using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.CQRS.Commands.Response;
using MediatR;

namespace api1.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
