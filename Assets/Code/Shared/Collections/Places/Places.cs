using System;

using UnityEngine;

namespace Framework.Shared.Collections
{
    public class Places<T> : IPlaces<T>
    {
        private Pair[] pairs;

        private int index;

        public Places(Pair[] pairs)
        {
            this.pairs = pairs;
        }

        private ref Pair Current => ref pairs[index];

        public T ToAttacks() => PlaceToPosition(ref Current.attacker);
        public T ToDefends() => PlaceToPosition(ref Current.defender);
        public T Place()
        {
            ref Item attacker = ref Current.attacker;
            ref Item defender = ref Current.defender;

            if (attacker.IsEmpty)
                return ToAttacks();

            if (defender.IsEmpty)
                return ToDefends();

            return ToAttacks();
        }

        private T PlaceToPosition(ref Item place)
        {
            ref Item temp = ref place;

            if (temp.Contains)
            {
                Next();

                temp = ref Current.attacker;
            }

            temp.Set();

            return temp.Transform;
        }

        public void Clear()
        {
            index = 0;

            for (int i = 0; i < pairs.Length; i++)
            {
                ref Pair pair = ref pairs[i];

                pair.Clear();
            }
        }

        private void Next()
        {
            index++;
        }


        [Serializable]
        public struct Pair
        {
            public Item attacker;
            public Item defender;

            public void Clear()
            {
                attacker.Clear();
                defender.Clear();
            }
        }

        [Serializable]
        public struct Item
        {
            [SerializeField] private T place;

            public T Transform => place;

            public bool Contains { get; private set; }
            public bool IsEmpty => Contains == false;

            public void Set() => Contains = true;
            public void Clear() => Contains = false;
        }
    }
}