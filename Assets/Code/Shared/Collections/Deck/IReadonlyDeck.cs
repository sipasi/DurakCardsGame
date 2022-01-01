


using System.Collections.Generic;

namespace ProjectCard.Shared.Collections
{
    public interface IReadonlyDeck<T> : IReadOnlyCollection<T>
    {
        bool IsEmpty { get; }

        T Top { get; }
        T Bottom { get; }
    }
}