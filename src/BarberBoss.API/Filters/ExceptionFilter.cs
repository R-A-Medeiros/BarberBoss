using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is BarberBossException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
        
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var barberBossException = context.Exception as BarberBossException;
        var errorResponse = new ResponseErrorJson(barberBossException!.GetErros());

        context.HttpContext.Response.StatusCode = barberBossException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unknown error");
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
