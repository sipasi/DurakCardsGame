
using System;
using System.Collections.Generic;

using Framework.Durak.Datas;

namespace Framework.Durak.Players
{
    [Serializable]
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PlayerType Type { get; set; }

        public List<Data> Cards { get; set; }
        public IReadOnlyList<Data> Hand => Cards;

        public void Add(Data data) => Cards.Add(data);
        public void AddRange(IEnumerable<Data> datas)
        {
            throw new NotImplementedException();
        }

        public void Remove(Data data) => Cards.Remove(data);

        public bool Contains(Data data) => Cards.Contains(data);

        public void Clear() => Cards.Clear();

        public override string ToString() => $"Name: {Name}. Selector: {Type}";
    }
}