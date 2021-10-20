
using System;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerStorage : MonoBehaviour
    {
        private PlayerInfo[] players;

        private List<PlayerInfo> active;
        private List<PlayerInfo> removed;

        public IReadOnlyList<PlayerInfo> All => players;
        public IReadOnlyList<PlayerInfo> Active => active;
        public IReadOnlyList<PlayerInfo> Removed => removed;


        public void Initialize(PlayerInfo[] players)
        {
            this.players = players;

            active = new List<PlayerInfo>(players);
            removed = new List<PlayerInfo>(players.Length);
        }

        public int IndexOf(PlayerInfo player) => active.IndexOf(player);

        public bool Remove(PlayerInfo player)
        {
            if (active.Remove(player))
            {
                removed.Add(player);

                return true;
            }

            return false;
        }
        public void RemoveRange(IEnumerable<PlayerInfo> players)
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

        public List<PlayerInfo>.Enumerator GetEnumerator() => active.GetEnumerator();

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