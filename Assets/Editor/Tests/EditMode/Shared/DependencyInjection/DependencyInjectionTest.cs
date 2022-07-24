
using System;

using NUnit.Framework;

namespace Framework.Shared.DependencyInjection.Tests
{
    public class DependencyInjectionTest
    {
        [Test]
        public void TestSingleton()
        {
            ServiceBuilder builder = new ServiceBuilder();

            builder.singleton.Add<IGuidService, GuidService>();
            builder.singleton.Add<IGuidProvider, GuidProvider>();

            Test<IGuidService>(builder, (first, second) => object.ReferenceEquals(first, second) is true);
        }
        [Test]
        public void TestTransient()
        {
            ServiceBuilder builder = new ServiceBuilder();

            builder.transient.Add<IGuidService, GuidService>();
            builder.transient.Add<IGuidProvider, GuidProvider>();

            Test<IGuidService>(builder, (first, second) => object.ReferenceEquals(first, second) is false);
        }


        private void Test<T>(ServiceBuilder builder, Func<T, T, bool> assert) where T : class
        {
            IDiContainer container = builder.Build();

            var first = container.Get<T>();
            var second = container.Get<T>();

            Assert.IsNotNull(first);
            Assert.IsNotNull(second);

            var result = assert.Invoke(first, second);

            Assert.IsTrue(result);
        }
    }
}