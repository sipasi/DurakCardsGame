using System;
using System.IO;

using UnityEngine;

namespace Framework.Shared.Serializations
{
    public abstract class Serializer : ISerializer
    {
        public bool Serialize<T>(Stream stream, T data)
        {
            var type = typeof(T);

            try
            {
                SerializeObject(stream, data);
            }
            catch (Exception ex)
            {
                string exception = ex.Message;

                Message(log: Debug.LogWarning, action: nameof(SerializeObject), exception);

                return false;
            }

            return true;
        }
        public T Deserialize<T>(Stream stream)
        {
            T result = default;

            var type = typeof(T);

            try
            {
                result = DeserializeObject<T>(stream);
            }
            catch (Exception ex)
            {
                string exception = ex.Message;

                Message(log: Debug.LogWarning, action: nameof(DeserializeObject), exception);

                return default;
            }

            return result;
        }

        protected abstract void SerializeObject<T>(Stream stream, T data);
        protected abstract T DeserializeObject<T>(Stream stream);

        private void Message(Action<object> log, string action, string exception = null)
        {
            string text = $"Can't {action}.\nException Message: {exception}";

            log.Invoke(text);
        }
    }
}