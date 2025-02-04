using FluentValidation;
using MediatR;

namespace ClenaArch.Application.Members.Commands.Validations;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any()) 
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var faluires = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if(faluires.Count != 0)
            {
                throw new ValidationException(faluires);
            }
        }

        return await next();
    }
}
