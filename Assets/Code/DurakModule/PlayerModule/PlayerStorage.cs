#nullable enable

using System;
using System.Collections.Generic;

namespace ProjectCard.DurakModule.PlayerModule
{ 
    [Serializable]
    public class PlayerStorage : IPlayerStorage
    {
        private readonly IReadOnlyList<IPlayer> players;

        private readonly List<IPlayer> active;
        private readonly List<IPlayer> removed;

        public IReadOnlyList<IPlayer> All => players;
        public IReadOnlyList<IPlayer> Active => active;
        public IReadOnlyList<IPlayer> Removed => removed;


        public PlayerStorage(IReadOnlyList<IPlayer> players)
        {
            this.players = players;

            this.active = new List<IPlayer>(players);
            this.removed = new List<IPlayer>(players.Count);
        }


        public int IndexOf(IPlayer player) => active.IndexOf(player);
        public IPlayer? ById(Guid id)
        {
            foreach (var item in players)
            {
                if (item.Id == id) return item;
            }

            return null;
        }

        public bool Remove(IPlayer player)
        {
            if (active.Remove(player))
            {
                removed.Add(player);

                return true;
            }

            return false;
        }
        public void RemoveRange(IEnumerable<IPlayer> players)
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

        public List<IPlayer>.Enumerator GetEnumerator() => active.GetEnumerator();

        public void Restore()
        {
            active.Clear();
            removed.Clear();

            active.AddRange(players);

            foreach (var player in players)
            {
                player.Hand.Clear();
            }
        }
    }
}