
using System;
using System.IO;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace ProjectCard.Shared.SerializationModule
{
    public abstract class Serializer : ISerializer, IDeserializer
    {
        public async UniTask<T> Deserialize<T>(Stream stream)
        {
            T result = default;

            var type = typeof(T);

            try
            {
                result = await DeserializeObject<T>(stream);
            }
            catch (Exception ex)
            {
                string exception = ex.Message;

                Message(log: Debug.LogWarning, action: nameof(DeserializeObject), exception);

                return default;
            }

            return result;
        }
        public async UniTask<bool> Serialize<T>(Stream stream, T data)
        {
            var type = typeof(T);

            try
            {
                await SerializeObject(stream, data);
            }
            catch (Exception ex)
            {
                string exception = ex.Message;

                Message(log: Debug.LogWarning, action: nameof(SerializeObject), exception);

                return false;
            }

            return true;
        }

        protected abstract UniTask<T> DeserializeObject<T>(Stream stream);
        protected abstract UniTask SerializeObject<T>(Stream stream, T data);

        private void Message(Action<object> log, string action, string exception = null)
        {
            string text = $"Can't {action}.\nException Message: {exception}";

            log.Invoke(text);
        }
    }
}
