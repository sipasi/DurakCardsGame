using System;

using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.SaveModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.SaveModule
{
    public sealed class PlayerQueueSaverLoader : EntitySaverLoader<IPlayerQueue>
    {
        [SerializeField] private PlayerStorageEntity playerStorageEntity;

        public override void Load(IStorage<Guid> storage)
        {
            var saveData = storage.Restore<PlayerQueueSaveData>(Key);

            var playerStorage = playerStorageEntity.Entity;

            Assert.IsNotNull(playerStorage, $"Can't create {nameof(IPlayerQueue)} while {nameof(IPlayerStorage)} not loaded");
            Assert.IsTrue(playerStorage.All.Count > 0, $"Can't create {nameof(IPlayerQueue)} without players");

            var playerQueue = new PlayerQueue(playerStorage);

            saveData.Set(playerQueue, playerStorage);

            InitializeEntity(playerQueue);
        }

        public override void Save(IStorage<Guid> storage)
        {
            storage.Store(Key, new PlayerQueueSaveData(Data));
        }

        [Serializable]
        private class PlayerQueueSaveData
        {
            private PlayerActionType action;
            private Guid attacker;
            private Guid defender;


            public PlayerQueueSaveData(IPlayerQueue playerQueue)
            {
                action = playerQueue.Action;

                attacker = playerQueue.Attacker.Id;
                defender = playerQueue.Defender.Id;
            }


            public void Set(IPlayerQueue playerQueue, IPlayerStorage players)
            {
                playerQueue.Set(players.ById(attacker), players.ById(defender), action);
            }
        }
    }
}
