using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Saas.Business.Respositories;

namespace Saas.Business.Autofac
{
    public class BusinessAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhotoSqlDbContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
