
using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ToolModule;
using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.DurakModule.PlayerModule
{
    public static class PlayerTool
    {
        public static PlayerInfo DefineFirstPlayerBySmallestTrump(PlayerStorage players, Deck<Data> deck)
            => DefineFirstPlayerBySmallestTrump(players.Active, deck.Bottom);

        public static PlayerInfo DefineFirstPlayerBySmallestTrump(IReadOnlyList<PlayerInfo> active, Data trump)
        {
            PlayerInfo first = default;
            Data smallest = default;

            foreach (var player in active)
            {
                if (DataTool.TryGetSmallestTrump(player.Hand.Datas, trump, out var result))
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