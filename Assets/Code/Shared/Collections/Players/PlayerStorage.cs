#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    [Serializable]
    public class PlayerStorage<T> : IPlayerStorage<T>
    {
        private readonly IReadOnlyList<T> players;

        private readonly List<T> active;
        private readonly List<T> removed;

        public int Count => active.Count;

        public IReadOnlyList<T> All => players;
        public IReadOnlyList<T> Active => active;
        public IReadOnlyList<T> Removed => removed;

        public T this[int index] => active[index];


        public PlayerStorage(IReadOnlyList<T> players)
        {
            this.players = players;

            this.active = new List<T>(players);
            this.removed = new List<T>(players.Count);
        }


        public int IndexOf(T player) => active.IndexOf(player);

        public bool IsActive(T player) => active.Contains(player);

        public bool Remove(T player)
        {
            if (active.Remove(player))
            {
                removed.Add(player);

                return true;
            }

            return false;
        }
        public void RemoveRange(IEnumerable<T> players)
        {
            if (players == Active)
            {
                throw new ArgumentException($"Parameter {nameof(players)} cant be the same source than {nameof(Active)}");
            }

            foreach (var player in players)
            {
                Remove(player);
            }
        }

        public void Restore()
        {
            active.Clear();
            removed.Clear();

            active.AddRange(players);
        }

        public ListEnumerator<T> GetEnumerator() => new ListEnumerator<T>(active);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}