


using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IReadonlyDeck<T> : IReadOnlyCollection<T>
    {
        bool IsEmpty { get; }

        T Top { get; }
        T Bottom { get; }
    }
}