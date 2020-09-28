using ExampleMediatR.Mapping;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;
using MediateRCQRSExample.Queires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediateRCQRSExample.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        
             private readonly ICustomersRepository _customersRepository;
             private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
    
        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var Customers = await _customersRepository.GetCustomersAsync();

            return _mapper.MapCustomerDtosToCustomerResponses(Customers);
        }
    }
}
