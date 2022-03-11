using System;


namespace Framework.Shared.DependencyInjection
{
    internal interface IServiceCreator
    {
        object CreateService(Type type, IDiContainer container);
    }
}