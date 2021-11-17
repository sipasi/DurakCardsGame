using System.Collections.Generic;

namespace ProjectCard.Shared.CollectionModule
{
    public interface IReadonlyIndexCollection : IReadOnlyCollection<int>
    {
        public int Capacity { get; }
        public bool IsEmpty { get; }

        new ArrayEnumerator<int> GetEnumerator();
    }
}