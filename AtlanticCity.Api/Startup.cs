using AtlanticCity.Api.Core;
using AtlanticCity.Core.Core;
using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Infraestructure.Extensions;
using AtlanticCity.Infraestructure.Filters;
using AtlanticCity.Infraestructure.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace AtlanticCity.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var applicationSettings = Configuration.GetSection("AppSettings");

            services.AddSingleton<ISettings, Settings>(e => applicationSettings.Get<Settings>());
            services.Configure<Settings>(applicationSettings);

            services
                .AddCors(option => option.AddPolicy("allowedOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()))
                .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((_) => "El campo es obligatorio");
                options.Filters.Add(typeof(ControllerFilterAttribute));
                options.Filters.Add(typeof(GlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services
                .AddDirectoryBrowser()
                .AddDistributedMemoryCache()
                .AddOptions(Configuration)
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddServices()
                .AddSwagger(applicationSettings.Get<Settings>(), GetXmlCommentsPath());

            services.AddControllers(op => op.Filters.Add<ValidationFilter>())
                   .AddFluentValidation(op => op.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("Logs/PruebaCA-{Date}.txt", LogLevel.Error);
            app.UseStaticFiles();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Logs")),
                RequestPath = "/" + "Logger",
                EnableDirectoryBrowsing = true
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba CA V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
        private string GetXmlCommentsPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}
