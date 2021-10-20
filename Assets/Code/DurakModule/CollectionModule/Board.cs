using System.Collections.Generic;

using ProjectCard.Shared.CollectionModule.ExtensionModule;

namespace ProjectCard.DurakModule.CollectionModule
{
    public class Board<T>
    {
        private readonly List<T> all;
        private readonly List<T>[] places;
        private readonly int rowItemsCount;

        private int index;

        public IReadOnlyList<T> All => all;
        public IReadOnlyList<T> Attacks => places[BoardIndexes.attacks];
        public IReadOnlyList<T> Defends => places[BoardIndexes.defends];

        public bool IsAttacksPlace => index == BoardIndexes.attacks;
        public bool IsDefendsPlace => index == BoardIndexes.defends;

        public bool IsEmpty => Count == 0;
        public bool IsFull => Defends.Count == rowItemsCount;


        public int Count => places[BoardIndexes.attacks].Count + places[BoardIndexes.defends].Count;


        public Board(int rowItemsCount)
        {
            this.all = new List<T>(rowItemsCount * BoardIndexes.count);
            this.places = new List<T>[BoardIndexes.count];
            this.rowItemsCount = rowItemsCount;

            for (int i = 0; i < BoardIndexes.count; i++)
            {
                places[i] = new List<T>(rowItemsCount);
            }
        }


        public void Add(T item)
        {
            List<T> place = places[index];

            if (place.Count == rowItemsCount)
            {
                throw new System.ArgumentException();
            }
            if (place.Contains(item))
            {
                throw new System.ArgumentException();
            }

            index = (index + 1) % BoardIndexes.count;

            all.Add(item);
            place.Add(item);
        }

        public bool TryGetLast(out T item)
        {
            int lastIndex = (index + 1) % BoardIndexes.count;

            List<T> place = places[lastIndex];

            item = place.Last();

            return place.IsNotEmpty();
        }

        public void Clear()
        {
            foreach (var place in places)
            {
                place.Clear();
            }

            all.Clear();

            index = 0;
        }

        public IEnumerator<T> GetEnumerator() => all.GetEnumerator();

        private readonly struct BoardIndexes
        {
            public const int attacks = 0;
            public const int defends = 1;
            public const int count = 2;
        }
    }
}