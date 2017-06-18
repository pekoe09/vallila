using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using Vallila.Services;
using Vallila.Services.Implementations;
using Vallila.Persistence.Repositories;
using Vallila.Persistence.Repositories.Implementations;

namespace Vallila.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // bind service interfaces to implementation classes
            kernel.Bind<IActivityService>().To<ActivityService>();

            // bind repository interfaces to implementation classes
            kernel.Bind<IActivityRepository>().To<ActivityRepository>();

        }
    }
}