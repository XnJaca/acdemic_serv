using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

public class ValidationFilter<T>: IAsyncActionFilter where T : class {
    private readonly IValidator<T>? _validator;

    public ValidationFilter ( IValidator<T>? validator ) {
        _validator = validator;
    }

    public async Task OnActionExecutionAsync ( ActionExecutingContext context, ActionExecutionDelegate next ) {
        if ( context.ActionArguments.TryGetValue("data", out var argument) && argument is T entityToValidate ) {
            if ( _validator is not null ) {
                var validationResult = await _validator.ValidateAsync(entityToValidate, context.HttpContext.RequestAborted);
                if ( !validationResult.IsValid ) {
                    context.Result = new ObjectResult(new ValidationProblemDetails(validationResult.ToDictionary())) {
                        StatusCode = ( int )HttpStatusCode.UnprocessableEntity
                    };
                    return;
                }
            }
        } else {
            context.Result = new ObjectResult(new ValidationProblemDetails(new Dictionary<string, string []> {
                [ "" ] = new [] { "A non-empty request body is required." }
            })) {
                StatusCode = ( int )HttpStatusCode.BadRequest
            };
            return;
        }
         
        await next();
    }
}
