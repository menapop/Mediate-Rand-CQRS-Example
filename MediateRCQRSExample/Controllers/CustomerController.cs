using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleMediatR.Responses;
using MediateRCQRSExample.Queires;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediateRCQRSExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
       
        public async Task<ActionResult<List<CustomerResponse>>> GetCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
