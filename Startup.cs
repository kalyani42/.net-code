using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetECINo.Repository;
using GetECINo.Middleware;
using Serilog;
using GetECINo.Models;
using GetECINo.Helpers;
using StackExchange.Profiling;

namespace GetECIno
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
            Console.WriteLine("I am here");
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
            services.AddControllers();
            services.AddSwaggerDocument();
            services.Configure<UserSettings>(options =>{ Configuration.GetSection("UserSettings").Bind(options); });
            services.Configure<DatabaseSettings>(options => { Configuration.GetSection("DatabaseSettings").Bind(options); });
            services.AddSingleton<IDataRepository, DataRepository>();
            if (Configuration["UserSettings:EnableMiniProfiler"] == "True")
            {
                services.AddMiniProfiler(options =>
                {
                    options.RouteBasePath = Configuration["UserSettings:BasePath"] + "/miniprofiler";
                    options.IgnorePath("/swagger");
                    options.IgnorePath("/miniprofiler");
                });
            }
            
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Console.WriteLine("added a new line");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (Configuration["UserSettings:EnableMiniprofiler"] == "True")
            {
                app.UseMiniProfiler();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();
            app.UseMiddleware(typeof(AuditMiddleware));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
