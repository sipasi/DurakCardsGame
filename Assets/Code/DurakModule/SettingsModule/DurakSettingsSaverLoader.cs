
using System;

using ProjectCard.DurakModule.GameModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.SettingsModule;

using UnityEngine;

namespace ProjectCard.DurakModule.SettingsModule
{
    public sealed class DurakSettingsSaverLoader : SettingsSaverLoader
    {
        [SerializeField] private ScriptableItem<GamePlayersType> gamePlayersType;

        protected override void Save(IStorage<Guid> storage)
        {
            storage.Store(gamePlayersType.Key, new LoadPropertiesSaveData(gamePlayersType.Data));
        }
        protected override void Load(IStorage<Guid> storage)
        {
            var data = storage.Restore<LoadPropertiesSaveData>(gamePlayersType.Key);

            if (data != null)
            {
                data.CopyTo(gamePlayersType.Data);
            }
        }

        [Serializable]
        private class LoadPropertiesSaveData
        {
            public PlayersType PlayersType { get; set; }

            public LoadPropertiesSaveData(GamePlayersType loadProperties)
            {
                PlayersType = loadProperties.PlayersType;
            }

            public void CopyTo(GamePlayersType durakLoadProperties)
            {
                durakLoadProperties.PlayersType = PlayersType;
            }
        }
    }
}
