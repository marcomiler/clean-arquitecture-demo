using AtlanticCity.Core.Core;
using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Core.Interfaces.IServices.PruebaCA;
using AtlanticCity.Core.Services.PruebaCA;
using AtlanticCity.Infraestructure.Connections;
using AtlanticCity.Infraestructure.Options;
using AtlanticCity.Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace AtlanticCity.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IEstadoService, EstadoService>();

            services.AddTransient<IMongoDBContext, MongoDBContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUnitOfWorkMongoDB, UnitOfWorkMongoDB>();
           

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOptions>(op => configuration.GetSection("TokenOptions").Bind(op));
            services.Configure<MongoOptions>(op => configuration.GetSection("ConnectionStringsMongoDB").Bind(op));

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services,Settings settings,  string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                var contact = new OpenApiContact() { Name = settings.ContactName, Url = new Uri(settings.ContactUrl) };
                doc.SwaggerDoc(settings.DocNameV1,
                                           new OpenApiInfo
                                           {
                                               Title = settings.DocInfoTitle,
                                               Version = settings.DocInfoVersion,
                                               Description = settings.DocInfoDescription,
                                               Contact = contact
                                           }
                                            );

                doc.CustomSchemaIds(i => i.FullName);
                doc.IncludeXmlComments(xmlFileName);
                doc.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });

            return services;
        }

    }
}
