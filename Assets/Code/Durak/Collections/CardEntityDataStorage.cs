using System;
using System.Collections.Generic;

using Framework.Durak.Cards;
using Framework.Shared.Cards.Entities;

using UnityEngine;


namespace Framework.Durak.Collections
{
    public class CardEntityDataStorage : MonoBehaviour
    {
        [SerializeField] private CardEntityDataMap storage;

        private readonly List<ICard> cards = new List<ICard>();
        private readonly List<Data> datas = new List<Data>();

        public IReadOnlyList<ICard> Cards => cards;
        public IReadOnlyList<Data> Datas => datas;

        public int Count => cards.Count;

        public bool Contains(ICard entity) => cards.Contains(entity);
        public bool Contains(Data entity) => datas.Contains(entity);

        public void Add(ICard card)
        {
            Data data = storage.Get(card);

            Add(card, data);
        }
        public void Add(Data data)
        {
            ICard card = storage.Get(data);

            Add(card, data);
        }

        public void AddRange(IReadOnlyList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                ICard card = cards[i];
                Add(card);
            }
        }
        public void AddRange(IReadOnlyList<Data> datas)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                Data data = datas[i];
                Add(data);
            }
        }

        public void Remove(ICard card)
        {
            Data data = storage.Get(card);

            Remove(card, data);
        }
        public void Remove(Data data)
        {
            ICard card = storage.Get(data);

            Remove(card, data);
        }

        public void Clear()
        {
            cards.Clear();
            datas.Clear();
        }

        private void Add(ICard card, Data data)
        {
            cards.Add(card);
            datas.Add(data);
        }

        private void Remove(ICard card, Data data)
        {
            if (Contains(card) is false || Contains(data) is false)
            {
                throw new ArgumentException();
            }

            cards.Remove(card);
            datas.Remove(data);
        }
    }
}