using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pipeline.Middlewares
{
    public class SimpleMiddlewares
    {
        private readonly RequestDelegate _next;
        public SimpleMiddlewares(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync(text: "<Div>hello simpleware</Div>");
            await _next(context);
            await context.Response.WriteAsync(text: "<Div> bye simpleware </Div>");
        }
    }
}
