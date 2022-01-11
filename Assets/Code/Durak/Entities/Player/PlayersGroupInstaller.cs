using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class PlayersGroupInstaller : IEntityInstaller<PlayerEntity[]>
    {
        [SerializeField] private PlayerInstaller[] installers;

        public void Install(PlayerEntity[] entities)
        {
            Assert.AreEqual(entities.Length, installers.Length, $"Players entities: {entities.Length}, installers: {installers.Length}");

            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                var installer = installers[i];

                installer.Install(entity);
            }
        }
    }
}
