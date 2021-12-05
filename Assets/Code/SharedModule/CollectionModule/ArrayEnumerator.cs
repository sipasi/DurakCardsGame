


namespace ProjectCard.Shared.CollectionModule
{
    public struct ArrayEnumerator<T>
    {
        private readonly T[] array;

        private readonly int count;
        private readonly int from;

        private int index;


        public ArrayEnumerator(T[] array, int from, int count)
        {
            this.array = array;
            this.from = from;
            this.count = count;

            index = -1;
        }


        public T Current => array[from + index];

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