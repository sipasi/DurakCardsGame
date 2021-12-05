
using System;

using Cysharp.Threading.Tasks;

using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.SaveModule;
using ProjectCard.Shared.ScriptableModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;

namespace ProjectCard.Shared.SettingsModule
{
    public class SettingsSaverLoader : MonoBehaviour
    {
        [SerializeField] private GuidSaveService settingsStorage;

        [Header("Save")]
        [SerializeField] private ScriptableItem<SpeedVariables> animations;

        public async void LoadAsyncVoid() => await Load();
        public async void SaveAsyncVoid() => await Save();

        public async UniTask Load()
        {
            await settingsStorage.LoadStorage();

            var data = settingsStorage.Restore<AnimationSpeedSaveData>(animations.Key);

            if (data != null)
            {
                data.CopyTo(animations.Data);
            }

            Load(settingsStorage);
        }
        public async UniTask Save()
        {
            await settingsStorage.LoadStorage();

            settingsStorage.Clear();

            settingsStorage.Store(animations.Key, new AnimationSpeedSaveData(animations.Data));

            Save(settingsStorage);

            await settingsStorage.SaveStorage();
        }

        protected virtual void Load(IStorage<Guid> storage) { }
        protected virtual void Save(IStorage<Guid> storage) { }


        [Serializable]
        protected struct ScriptableItem<T> where T : ScriptableObject
        {
            [SerializeField] private T value;

            [SerializeField] private SaveKey key;

            public T Data => value;
            public Guid Key => key.Key;
        }
        [Serializable]
        private class AnimationSpeedSaveData
        {
            public float CardMovement { get; set; }

            public AnimationSpeedSaveData(SpeedVariables animations)
            {
                CardMovement = animations.CardMovement;
            }

            public void CopyTo(SpeedVariables animations)
            {
                animations.CardMovement = CardMovement;
            }
        }
    }
}