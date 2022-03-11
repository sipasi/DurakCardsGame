
using System;

namespace Framework.Shared.DependencyInjection.Tests
{
    public interface IGuidProvider
    {
        Guid Guid { get; }
    }
}