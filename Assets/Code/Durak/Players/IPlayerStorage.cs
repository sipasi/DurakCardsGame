

using System;
using System.Collections.Generic;

namespace Framework.Durak.Players
{
    public interface IPlayerStorage
    {
        IReadOnlyList<IPlayer> All { get; }
        IReadOnlyList<IPlayer> Active { get; }
        IReadOnlyList<IPlayer> Removed { get; }

        int IndexOf(IPlayer player);
        IPlayer ById(Guid id);

        bool IsActive(IPlayer player);

        bool Remove(IPlayer player);
        void RemoveRange(IEnumerable<IPlayer> players);

        List<IPlayer>.Enumerator GetEnumerator();

        void Restore();
    }
}