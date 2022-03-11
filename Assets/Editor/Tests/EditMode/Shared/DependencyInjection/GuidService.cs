
using System;

namespace Framework.Shared.DependencyInjection.Tests
{
    public class GuidService : IGuidService
    {
        private readonly IGuidProvider provider;

        public GuidService(IGuidProvider provider)
        {
            this.provider = provider;
        }

        public Guid GetGuid() => provider.Guid;
    }
}