using System.Collections.Generic;
using System.Linq;

using Framework.Shared.Collections;

namespace Framework.Durak.Players
{
    public static class Eliminator
    {
        public static IReadOnlyList<T> Eliminate<T>(IReadOnlyList<T> active)
            where T : IReadonlyPlayer
        {
            var empty = active.Where(player => player.Hand.Count == 0).ToList();

            return empty;
        }
    }
}