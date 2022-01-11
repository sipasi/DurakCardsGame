using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class PlayerQueueInstaller : IEntityInstaller<PlayerQueueEntity>
    {
        [SerializeField] private PlayerStorageEntity storageEntity;

        public void Install(PlayerQueueEntity entity)
        {
            Assert.IsNotNull(storageEntity, "Can't initialize a PlayerQueue before a PlayerStorage has been initialized");

            IPlayerQueue<IReadonlyPlayer> queue = new PlayerQueue<IReadonlyPlayer>(storageEntity.GetStorage());

            entity.Initialize(queue);
        }
    }
}