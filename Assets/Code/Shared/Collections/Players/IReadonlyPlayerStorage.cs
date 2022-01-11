

using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IReadonlyPlayerStorage<T> : IReadOnlyList<T>
    {
        IReadOnlyList<T> All { get; }
        IReadOnlyList<T> Active { get; }
        IReadOnlyList<T> Removed { get; }

        int IndexOf(T player);

        bool IsActive(T player);

        new ListEnumerator<T> GetEnumerator();
    }
}