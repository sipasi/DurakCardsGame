using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Views;

namespace Framework.Durak.Entities
{
    public interface IDiscardPileEntity
    {
        IReadOnlyList<Data> Value { get; }

        UniTask Place(Data data);
        UniTask PlaceRange(IEnumerable<Data> datas);
    }
}