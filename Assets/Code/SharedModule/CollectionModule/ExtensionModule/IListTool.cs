using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.Shared.CollectionModule.ExtensionModule
{
    public static class IListTool
    {
        public static IList<T> Randomize<T>(IList<T> array, int from, int to, int times = 1)
        {
            for (int step = 0; step < times; step++)
            {
                for (int current = 0; current < to; current++)
                {
                    int next = Random.Range(from, to);

                    T currentItem = array[current];
                    T nextItem = array[next];

                    array[current] = nextItem;
                    array[next] = currentItem;
                }
            }

            return array;
        }
    }
}