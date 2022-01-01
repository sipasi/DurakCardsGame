using System;
using System.Collections;
using System.Collections.Generic;

using ProjectCard.Shared.Collections.Extensions;

namespace ProjectCard.Shared.Collections
{
    [Serializable]
    public sealed class DecrementalIndexes : IIndexCollection
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
        public int Peek(int offset)
        {
            int index = (size - 1) + (offset * -1);

            return array[index];
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

        public ArrayEnumerator<int> GetEnumerator()
        {
            var enumerator = new ArrayEnumerator<int>(array, from: 0, count: size);

            return enumerator;
        }

        private int NextIndex() => --size;


        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return array[i];
            }
        }
    }
}