using System;


namespace Framework.Shared.DependencyInjection
{
    public interface IDiContainer
    {
        T Get<T>() where T : class;
        object Get(Type type);
    }
}