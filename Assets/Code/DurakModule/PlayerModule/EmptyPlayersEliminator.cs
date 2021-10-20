using System.Collections.Generic;
using System.Linq;

namespace ProjectCard.DurakModule.PlayerModule
{
    public static class EmptyPlayersEliminator
    {
        public static void EliminateAndUpdateQueue(PlayerStorage storage, PlayerQueue queue)
        {
            List<PlayerInfo> eliminated = Eliminate(storage);

            UpdateQueueAfterPlayersEliminated(eliminated, storage, queue);
        }

        private static List<PlayerInfo> Eliminate(PlayerStorage storage)
        {
            var empty = storage.Active.Where(player => player.Hand.Count == 0).ToList();

            storage.RemoveRange(empty);

            return empty;
        }
        private static void UpdateQueueAfterPlayersEliminated(List<PlayerInfo> eliminated, PlayerStorage storage, PlayerQueue queue)
        {
            if (eliminated.Count == 0)
            {
                return;
            }

            var attaker = queue.Attacker;
            var defender = queue.Defender;

            if (eliminated.Contains(attaker))
            {
                storage.Remove(attaker);
                eliminated.Remove(attaker);
            }
            if (eliminated.Contains(defender))
            {
                storage.Remove(defender);
                eliminated.Remove(defender);
            }

            if (eliminated.Count == 0)
            {
                return;
            }

            foreach (var item in eliminated)
            {
                storage.Remove(item);
            }

            eliminated.Clear();
        }
    }
}