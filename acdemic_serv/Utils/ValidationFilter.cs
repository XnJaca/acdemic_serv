using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace acdemic_serv.Utils;

public class ValidationFilter<T>: IActionFilter where T : class {
    private readonly IValidator<T>? _validator;

    public ValidationFilter ( IValidator<T>? validator ) {
        _validator = validator;
    }

    public void OnActionExecuting ( ActionExecutingContext context ) {
        if ( context.ActionArguments.TryGetValue("data", out var argument) && argument is T entityToValidate ) {
            if ( _validator is not null ) {
                var validationResult = _validator.Validate(entityToValidate);
                if ( !validationResult.IsValid ) {
                    context.Result = new ObjectResult(new ValidationProblemDetails(validationResult.ToDictionary())) {
                        StatusCode = ( int )HttpStatusCode.UnprocessableEntity
                    };
                }
            }
        } else {
            context.Result = new ObjectResult(new ValidationProblemDetails(new Dictionary<string, string []> {
                [ "" ] = new [] { "A non-empty request body is required." }
            })) {
                StatusCode = ( int )HttpStatusCode.BadRequest
            };
        }
    }

    public void OnActionExecuted ( ActionExecutedContext context ) {
        // No necesitamos implementar esta parte.
    }
}
