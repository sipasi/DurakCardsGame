
using System.Collections.Generic;
using System.Linq;

using Framework.Durak.Datas;
using Framework.Durak.Datas.Tools;
using Framework.Shared.Collections;

namespace Framework.Durak.Players.Tools
{
    public static class PlayerTool
    {
        public static IReadonlyPlayer DefineFirstPlayerBySmallestTrump(IEnumerable<IReadonlyPlayer> active, IDeck<Data> deck)
            => DefineFirstPlayerBySmallestTrump(active, deck.Bottom);

        public static IReadonlyPlayer DefineFirstPlayerBySmallestTrump(IEnumerable<IReadonlyPlayer> active, Data trump)
        {
            IReadonlyPlayer first = default;
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

            return first ?? active.First();
        }
    }
}