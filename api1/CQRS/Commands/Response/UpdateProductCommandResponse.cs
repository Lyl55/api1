using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api1.CQRS.Commands.Response
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
    }
}
