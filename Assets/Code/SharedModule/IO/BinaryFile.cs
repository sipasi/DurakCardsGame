#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.IO
{
    public class BinaryFile : LocalFileSerializer
    {
        public BinaryFile(string path)
            : base(path) { }
        public BinaryFile(string directory, string name)
            : base(directory, name) { }

        [return: MaybeNull]
        protected override UniTask<T> DeserializeObject<T>(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var raw = formatter.Deserialize(stream);

            T? result = (T)raw;

            return UniTask.FromResult(result);
        }

        protected override UniTask SerializeObject<T>(Stream stream, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);

            return UniTask.CompletedTask;
        }
    }
}