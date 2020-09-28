﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediateRCQRSExample.Pipelinebehavioral
{
   
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre 
            var context = new ValidationContext<TRequest>(request);

            var failers = _validators.Select(x=>x.Validate(context))
                .SelectMany(x=>x.Errors)
                  .Where(x => x != null)
                .ToList();
            if (failers.Any())
            {
                 throw new  ValidationException(failers);
            }
            return next();
        }
    }
}
