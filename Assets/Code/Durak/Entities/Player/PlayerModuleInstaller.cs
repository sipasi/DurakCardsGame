using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class PlayerModuleInstaller : IEntityInstaller<(PlayerEntity[] players, PlayerStorageEntity storage, PlayerQueueEntity queue)>
    {
        [SerializeField] private PlayersGroupInstaller playersInstaller;
        [SerializeField] private PlayerStorageInstaller storageInstaller;
        [SerializeField] private PlayerQueueInstaller queueInstaller;

        public void Install((PlayerEntity[] players, PlayerStorageEntity storage, PlayerQueueEntity queue) entities)
        {
            playersInstaller.Install(entities.players);

            storageInstaller.Install(entities.storage);

            queueInstaller.Install(entities.queue);

            Assert.IsTrue(entities.players.Length == entities.storage.Value.All.Count);
        }
    }
}
