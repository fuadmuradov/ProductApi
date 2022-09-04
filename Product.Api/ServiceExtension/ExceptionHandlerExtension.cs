using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Product.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.ServiceExtension
{
    public static class ExceptionHandlerExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    int statusCode = 500;
                    string message = "Internal Server Error!";
                    if (contextFeature != null)
                    {
                        message = contextFeature.Error.Message;
                        if (contextFeature.Error is ItemNotFoundException)
                        {
                            statusCode = 404;
                        }
                    }
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        code = statusCode,
                        Message = message
                    });
                    await context.Response.WriteAsync(responseStr).ConfigureAwait(false);
                });
            });

        }
    }
}
