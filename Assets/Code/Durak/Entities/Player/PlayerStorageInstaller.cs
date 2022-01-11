
using Framework.Shared.Collections;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class PlayerStorageInstaller : IEntityInstaller<PlayerStorageEntity>
    {
        [SerializeField] private PlayerEntity[] entities;

        public void Install(PlayerStorageEntity entity)
        {
            foreach (var player in entities)
            {
                Assert.IsNotNull(player.Value, "Can't initialize a PlayerStorage before a Players has been initialized");
            }

            var storage = new PlayerStorage<IPlayerEntity>(entities);

            entity.Initialize(storage);
        }
    }
}