using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pipeline
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(text: "<Div>hello middleware 1</div>" );
                await next.Invoke();
                await context.Response.WriteAsync(text: "<Div>return middleware 1</Div>");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(text: "<Div>hello middleware 2</Div>");
                await next.Invoke();
                await context.Response.WriteAsync(text: "<Div>return middleware 2</Div>");
            });
            app.UseMiddleware<Middlewares.SimpleMiddlewares>();
            app.Run(handler:async(context) =>
            {
                await context.Response.WriteAsync(text: "<Div>hello midleware 3<Div>");
            });
        }
    }
}
