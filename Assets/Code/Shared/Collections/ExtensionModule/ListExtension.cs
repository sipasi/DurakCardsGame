using System.Collections.Generic;
 
namespace ProjectCard.Shared.Collections.Extensions
{
    public static class ListExtension
    {
        public static List<T> Randomize<T>(this List<T> list, int from, int to, int times = 1)
        {
            return IListTool.Randomize(list, from, to, times) as List<T>;
        }
        public static List<T> Randomize<T>(this List<T> list, int times = 1)
        {
            return IListTool.Randomize(list, from: 0, to: list.Count, times) as List<T>;
        }


        public static List<int> FillNubers(this List<int> list, int count)
        {
            list.Clear();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            return list;
        }
        public static List<int> FillNubers(this List<int> list)
        {
            list.Clear();

            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(i);
            }

            return list;
        }


        public static bool IsEmpty<T>(this IReadOnlyList<T> list) => list.Count == default;
        public static bool IsNotEmpty<T>(this IReadOnlyList<T> list) => list.Count > 0;

        public static T First<T>(this IReadOnlyList<T> list) => list.IsEmpty() ? default : list[0];
        public static T Last<T>(this IReadOnlyList<T> list) => list.IsEmpty() ? default : list[list.Count - 1];
    }
}