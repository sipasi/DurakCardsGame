#nullable enable


using System.Collections.Generic;

namespace ProjectCard.Shared.CollectionModule
{
    public interface IReadonlyDeck<T> : IReadOnlyCollection<T>
    {
        bool IsEmpty { get; }

        T Top { get; }
        T Bottom { get; }
    }
}