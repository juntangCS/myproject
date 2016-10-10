using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using AutoMapper;
using Granite.Autofac;
using Granite.AutoMapper;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Saas.Business.Autofac;
using Swashbuckle.Application;

namespace Granite
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly HttpConfiguration _httpConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            _httpConfiguration = new HttpConfiguration();
        }

        /// <summary>
        /// Configuartions the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            ConfigureWebApi(app);
            ConfigureAutoMapper();
            ConfigureSwagger();
        }
        
        private void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterModule(new WebApiAutofacModule());
            builder.RegisterModule(new BusinessAutofacModule());
            var container = builder.Build();
            _httpConfiguration.DependencyResolver =  new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(_httpConfiguration);
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            _httpConfiguration.MapHttpAttributeRoutes();
            var jsonFormatter = _httpConfiguration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(_httpConfiguration);
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
        }

        private void ConfigureSwagger()
        {
            _httpConfiguration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Granite");
                c.IncludeXmlComments(GetControllerXmlCommentsPath());
                c.UseFullTypeNameInSchemaIds();
            }).EnableSwaggerUi("docs/{*assetPath}", c => { c.DocExpansion(DocExpansion.List); });
        }

        private static string GetControllerXmlCommentsPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\bin\Granite.xml";
        }
    }
}