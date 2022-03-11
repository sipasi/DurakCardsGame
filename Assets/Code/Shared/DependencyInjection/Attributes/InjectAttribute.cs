using System;


namespace Framework.Shared.DependencyInjection
{
    [Obsolete("Not implement")]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class InjectAttribute : Attribute { }
}