using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace Granite.Autofac
{
    /// <summary>
    /// Autofac module.
    /// </summary>
    public class WebApiAutofacModule:Module
    {
        /// <summary>
        /// Loads the specified container builder.
        /// </summary>
        /// <param name="containerBuilder">The container builder.</param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}