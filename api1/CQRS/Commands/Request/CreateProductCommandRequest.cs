﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.CQRS.Commands.Response;
using MediatR;

namespace api1.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
