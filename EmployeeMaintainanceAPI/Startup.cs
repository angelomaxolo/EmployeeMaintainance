using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmployeeMaintainanceAPI.Core.Dtos;
using EmployeeMaintainanceAPI.Core.Models;
using EmployeeMaintainanceAPI.Core.Repositories;
using EmployeeMaintainanceAPI.Persistance;
using EmployeeMaintainanceAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace EmployeeMaintainanceAPI
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional: true,reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            var connectionString = Startup.Configuration["connectionStrings:EmployeeDBConnectionString"];
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); 

           services.AddDbContext<EmployeeContext>(o => o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              EmployeeContext employeeContext
                              )

        {
            loggerFactory.AddNLog();
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //it allows the ability to force browser to only be accessed over https
                //https strict transport security 
                app.UseHsts();
            }

            //This handles bouncing http requests to the https endpoint
            app.UseHttpsRedirection();

            employeeContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonWithoutEmployeeDto>();
                cfg.CreateMap<Person, PersonWithEmployeeDto>();
                cfg.CreateMap<Person, EmployeeDto>();
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<CreatePersonWithEmployeeInfoDto,Person>();
            });

            app.UseMvc();
        }
    }



}
