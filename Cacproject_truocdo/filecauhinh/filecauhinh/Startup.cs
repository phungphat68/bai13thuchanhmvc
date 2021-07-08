using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filecauhinh
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(handler: async (context) =>
             {
                 //await context.Response.WriteAsync(Configuration.GetSection(key: "Message").Value);
                 //await context.Response.WriteAsync(Configuration.GetSection(key: "ConnectionStrings:SQLServerConnectionString").Value);
                 //await context.Response.WriteAsync(Configuration.GetSection(key: "studen:0:age").Value +"<br>" );
                 //await context.Response.WriteAsync(Configuration.GetSection(key: "Arg1").Value);
                 await context.Response.WriteAsync(Configuration.GetSection(key: "PATH").Value);
             });           
             
        }
    }
}
