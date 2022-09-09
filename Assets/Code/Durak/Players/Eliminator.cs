using System.Collections.Generic;
using System.Linq;

namespace Framework.Durak.Players
{
    public static class Eliminator
    {
        public static IReadOnlyList<T> Eliminate<T>(IReadOnlyList<T> active)
            where T : IPlayer
        {
            var empty = active.Where(player => player.Hand.Count == 0).ToArray();

            return empty;
        }
    }
}