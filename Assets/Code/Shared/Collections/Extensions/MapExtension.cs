
namespace Framework.Shared.Collections.Extensions
{
    public static class MapExtension
    {
        public static T1 Get<T1, T2>(this IMap<T1, T2> map, in T2 item) => map.Reverse[item];
        public static T2 Get<T1, T2>(this IMap<T1, T2> map, in T1 item) => map.Forward[item];
    }
}