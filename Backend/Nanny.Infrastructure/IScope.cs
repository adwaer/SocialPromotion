using System;

namespace Nanny.Infrastructure
{
    public interface IScope
    {
        T Get<T>();
        object Get(Type type);
    }
}