using APP.STOREHOUSE.WEBAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APP.STOREHOUSE.WEBAPI.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BaseException e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(e.Errors)
                    .ContinueWith((_) => logger.LogError(e, Properties.ru_RU_Resources.ERROR_ExpectedCase));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(Properties.ru_RU_Resources.ERROR_UnexpectedCase)
                    .ContinueWith((_) => logger.LogError(e, Properties.ru_RU_Resources.ERROR_UnexpectedCase)); ;
            }
        }
    }
}
