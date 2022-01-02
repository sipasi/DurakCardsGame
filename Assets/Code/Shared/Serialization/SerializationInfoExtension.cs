
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Framework.Shared.Serializations
{
    public static class SerializationInfoExtension
    {
        public static T GetValue<T>(this SerializationInfo info, string name)
        {
            var type = typeof(T);

            var value = info.GetValue(name, type);

            T result = (T)value;

            return result;
        }

        public static Dictionary<T1, T2> GetDictionary<T1, T2>(this SerializationInfo info, string name)
        {
            var result = info.GetValue<Dictionary<T1, T2>>(name);

            return result;
        }
        public static List<T> GetList<T>(this SerializationInfo info, string name)
        {
            var result = info.GetValue<List<T>>(name);

            return result;
        }
        public static IReadOnlyList<T> GetReadonlyList<T>(this SerializationInfo info, string name)
        {
            var result = info.GetValue<IReadOnlyList<T>>(name);

            return result;
        }
        public static T[] GetArray<T>(this SerializationInfo info, string name)
        {
            var result = info.GetValue<T[]>(name);

            return result;
        }
    }
}
