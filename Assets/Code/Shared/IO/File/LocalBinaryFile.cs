using Framework.Shared.Serializations;

namespace Framework.Shared.IO
{
    public class LocalBinaryFile<T> : LocalFile<T>
    {
        public LocalBinaryFile(string path) : base(new BinarySerializer(), path) { }
    }
}