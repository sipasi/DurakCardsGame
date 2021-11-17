
using System;

using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.SaveModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;

namespace ProjectCard.DurakModule.SaveModule
{
    public class DurakGameSaver : MonoBehaviour
    {
        [SerializeField] private GuidSaveService saveService;

        [SerializeField] private SaveKey saveInfoKey;
        [SerializeField] private SaveKey gameplayDataKey;

        [SerializeField] private SaveEntitiesCollection saveEntities;


        public async UniTask SaveGame()
        {
            await saveService.LoadStorage();

            saveService.Clear();

            saveService.Store(saveInfoKey.Key, new SaveInfo("Durak"));
            saveService.Store(gameplayDataKey.Key, new GameplayData() { GameState = DurakGameState.PlayerAction });

            foreach (var savable in saveEntities.GetSavableEntities())
            {
                savable.Save(saveService);
            }

            await saveService.SaveStorage();
        }
    }
}