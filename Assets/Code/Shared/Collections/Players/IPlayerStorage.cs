using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IPlayerStorage<T> : IReadonlyPlayerStorage<T>
    {
        bool Remove(T player);
        void RemoveRange(IEnumerable<T> players);

        void Restore();
    }
}