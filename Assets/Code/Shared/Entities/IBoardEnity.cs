
using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;

namespace Framework.Shared.Entities
{
    public interface IBoardEnity<T> : IEntity
    {
        IReadonlyBoard<T> Value { get; }

        UniTask Place(T data);
        UniTask PlaceToAttacks(T data);
        UniTask PlaceToDefends(T data);
    }
}
