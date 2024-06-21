using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Common;
using System.Net;

namespace RentalCar.Api.Common.Exceptions
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                return;
            }

            if (context.Exception is ApplicationLayerException applicationLayerException)
            {
                context.Result = new ObjectResult(new ProblemDetails()
                {
                    Status = GetStatusCodeFromApplicationLayerExceptionType(applicationLayerException.Type),
                    Title = applicationLayerException.Title,
                    Detail = applicationLayerException.Detail
                });
            }
            else if (context.Exception is DomainLayerException domainLayerException)
            {
                context.Result = new ObjectResult(new ProblemDetails()
                {
                    Status = 400,
                    Title = domainLayerException.Title,
                    Detail = domainLayerException.Detail
                });
            }
            else
            {
                context.Result = new ObjectResult(new ProblemDetails()
                {
                    Status = 500,
                    Title = "INTERNAL_SERVER_ERROR"
                });
            }

            context.ExceptionHandled = true;
        }

        private int GetStatusCodeFromApplicationLayerExceptionType(ApplicationLayerExceptionType type)
        {
            HttpStatusCode statusCode;

            switch (type)
            {
                case ApplicationLayerExceptionType.NOT_FOUND:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ApplicationLayerExceptionType.VALIDATION_ERROR:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ApplicationLayerExceptionType.UNAUTHORIZED:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case ApplicationLayerExceptionType.INTERNAL_SERVER_ERROR:
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return (int)statusCode;
        }
    }
}
