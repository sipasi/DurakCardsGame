
using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Views;


namespace Framework.Durak.Players
{
    public interface IHand : IReadOnlyList<Data>
    {
        CardLookSide LookSide { get; }

        void Add(Data data);
        void AddRange(IEnumerable<Data> datas);

        void Remove(Data data);

        bool Contains(Data data);

        void Clear();
    }
}