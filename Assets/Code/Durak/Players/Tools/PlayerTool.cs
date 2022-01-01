
using System.Collections.Generic;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CardModule.ToolModule;
using ProjectCard.Shared.Collections;

namespace ProjectCard.Durak.PlayerModule
{
    public static class PlayerTool
    {
        public static IPlayer DefineFirstPlayerBySmallestTrump(IPlayerStorage players, IDeck<Data> deck)
            => DefineFirstPlayerBySmallestTrump(players.Active, deck.Bottom);

        public static IPlayer DefineFirstPlayerBySmallestTrump(IReadOnlyList<IPlayer> active, Data trump)
        {
            IPlayer first = default;
            Data smallest = default;

            foreach (var player in active)
            {
                if (DataTool.TryGetSmallestTrump(player.Hand, trump, out var result))
                {
                    if (first == null)
                    {
                        first = player;
                        smallest = result;
                        continue;
                    }

                    if (result.rank < smallest.rank)
                    {
                        first = player;
                        smallest = result;
                    }
                }
            }

            return first == null ? active[0] : first;
        }
    }
}