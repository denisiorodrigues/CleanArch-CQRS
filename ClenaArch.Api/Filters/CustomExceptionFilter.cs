using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClenaArch.Api.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validatioException)
        {
            var erros = validatioException.Errors
                .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                .ToList();

            context.Result = new ObjectResult(new { Errors = erros })
            {
                StatusCode = 404
            };
            context.ExceptionHandled = true;
        }
        else if (context.Exception is ArgumentException || context.Exception is KeyNotFoundException)
        {
            context.Result = new NotFoundObjectResult(new { Error = "Recurso não encontrado" });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is HttpRequestException || context.Exception is InvalidOperationException)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            context.ExceptionHandled = true;
        }
    }
}
