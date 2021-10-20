using ProjectCard.Shared.CollectionModule.ExtensionModule;

namespace ProjectCard.Shared.CollectionModule
{
    public sealed class DecrementalIndexes
    {
        private readonly int[] array;

        private int size;

        public int Count => size;
        public int Capacity => array.Length;
        public bool IsEmpty => Count == 0;


        public DecrementalIndexes(int count)
        {
            this.array = new int[count];

            Fill();

            ResetIndex();
        }


        public int Next()
        {
            int next = NextIndex();

            return array[next];
        }
        public int Peek()
        {
            return array[size - 1];
        }
        public int PeekFirst()
        {
            return array[0];
        }

        public void Fill()
        {
            array.FillNubers();
        }
        public void Randomize(int times) => array.Randomize(from: 0, to: size, times);
        public void Randomize(int from, int times) => array.Randomize(from: from, to: size, times);

        public void ResetIndex()
        {
            size = array.Length;
        }

        private int NextIndex() => --size;
    }
}