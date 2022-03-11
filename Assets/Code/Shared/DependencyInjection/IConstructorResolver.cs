using System;
using System.Reflection;


namespace Framework.Shared.DependencyInjection
{
    internal interface IConstructorResolver
    {
        ConstructorInfo GetConstructor(Type type);
    }
}