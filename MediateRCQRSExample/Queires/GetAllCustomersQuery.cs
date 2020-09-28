﻿using ExampleMediatR.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediateRCQRSExample.Queires
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
    {

    }
}
