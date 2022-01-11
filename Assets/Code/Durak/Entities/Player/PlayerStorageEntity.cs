
using Framework.Durak.Players;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class PlayerStorageEntity : MonoBehaviour, IPlayerStorageEntity
    {
        private IPlayerStorage<IReadonlyPlayer> storage;

        public IReadonlyPlayerStorage<IReadonlyPlayer> Value => storage;

        public void Initialize(IPlayerStorage<IReadonlyPlayer> storage) => this.storage = storage;

        public void EliminateEmpty()
        {
            var eliminated = Eliminator.Eliminate(storage.Active);

            storage.RemoveRange(eliminated);
        }

        internal IPlayerStorage<IReadonlyPlayer> GetStorage() => storage;
    }
}