
using Framework.Durak.Players;
using Framework.Shared.Collections;

namespace Framework.Durak.Entities
{
    public interface IPlayerStorageEntity
    {
        IReadonlyPlayerStorage<IPlayer> Value { get; }

        void EliminateEmpty();
    }
}