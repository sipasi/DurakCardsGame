
using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;

namespace Framework.Shared.Entities
{
    public interface IDeckEntity<T> : IEntity
    {
        IReadonlyDeck<T> Value { get; }

        bool TryPop(out T item);

        void Shuffle(int times);

        UniTask Reset();
    }
}
