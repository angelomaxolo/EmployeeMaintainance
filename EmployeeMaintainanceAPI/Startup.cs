using EmployeeMaintainance.Logic.Managers;
using EmployeeMaintainance.Logic.Managers.Interface;
using EmployeeMaintainance.Persistance.Persistance;
using EmployeeMaintainance.Persistance.Repositories;
using EmployeeMaintainance.Persistance.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Employee Maintenance API", Description = "Employee Maintenance Core API "});

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"EmployeeMaintainanceAPI.xml";
                c.IncludeXmlComments(xmlPath);
            });

            var connectionString = Startup.Configuration["connectionStrings:EmployeeDBConnectionString"];

            //register context as a scoped dependency using Factory
            services.AddDbContext<EmployeeContext>(options => { options.UseSqlServer(connectionString); })
                    .AddScoped<IEmployeeRepository, EmployeeRepository>()
                    .AddScoped<IPersonRepository, PersonRepository>()
                    .AddScoped<IPersonManager, PersonManager>()
                    .AddScoped<IEmployeeManager, EmployeeManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory)

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
            app.UseStatusCodePages();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Maintenance API");
                    c.RoutePrefix = string.Empty;
                });
        }
    }
}
