using System;
using Nanny.Infrastructure;

namespace Nanny.WebApi
{
    public class Scope : IScope
    {
        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            return Startup.HttpConfiguration.DependencyResolver.GetService(type);
        }
    }
}
