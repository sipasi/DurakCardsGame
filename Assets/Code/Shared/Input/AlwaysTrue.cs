#nullable enable

namespace Framework.Shared.Input
{
    internal sealed class AlwaysTrue<T> : IValidator<T>
    {
        public static IValidator<T> Instance { get; } = new AlwaysTrue<T>();

        private AlwaysTrue() { }

        public bool Validate(ref T _) => true;
    }
}