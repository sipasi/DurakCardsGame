using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IReadonlyIndexCollection : IReadOnlyCollection<int>
    {
        public int Capacity { get; }
        public bool IsEmpty { get; }

        new ArrayEnumerator<int> GetEnumerator();
    }
}