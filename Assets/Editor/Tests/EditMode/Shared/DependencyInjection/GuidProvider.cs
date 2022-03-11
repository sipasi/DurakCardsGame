
using System;

namespace Framework.Shared.DependencyInjection.Tests
{
    public class GuidProvider : IGuidProvider
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}