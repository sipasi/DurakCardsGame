
using System.Collections;
using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public struct ListEnumerator<T> : IEnumerator<T>
    {
        private readonly IReadOnlyList<T> list;

        private readonly int count;
        private readonly int from;

        private int index;


        public ListEnumerator(IReadOnlyList<T> list, int from, int count)
        {
            this.list = list;
            this.from = from;
            this.count = count;

            index = -1;
        }
        public ListEnumerator(IReadOnlyList<T> list)
        {
            this.list = list;
            this.from = 0;
            this.count = list.Count;

            index = -1;
        }


        public T Current => list[from + index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;

            return index < count;
        }

        public void Dispose()
        {
            index = -1;
        }
        public void Reset()
        {
            index = -1;
        }
    }
}