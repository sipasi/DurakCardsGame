
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.SaveModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.SaveModule
{
    public class SaveLoader : MonoBehaviour
    {
        [Header("State Machine")]
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Save")]
        [SerializeField] private GuidSaveService saveService;

        [SerializeField] private SaveKey saveInfoKey;
        [SerializeField] private SaveKey gameplayDataKey;

        [Header("Collection")]
        [SerializeField] private SaveEntitiesCollection saveEntities;

        public async UniTask LoadSave()
        {
            await saveService.LoadStorage();

            SaveInfo saveInfo = saveService.Restore<SaveInfo>(saveInfoKey.Key);
            GameplayData gameplayData = saveService.Restore<GameplayData>(gameplayDataKey.Key);

            Assert.IsNotNull(saveInfo);
            Assert.IsNotNull(gameplayData);

            string message =
                $"{nameof(SaveInfo)}:[{nameof(saveInfo.Title)}: {saveInfo.Title}, {nameof(saveInfo.Created)}: {saveInfo.Created}]\n" +
                $"{nameof(GameplayData)}:[{nameof(gameplayData.GameState)}: {gameplayData.GameState}]";

            Debug.Log(message);

            foreach (var loadable in saveEntities.GetLoadableEntities())
            {
                loadable.Load(saveService);
            }
        }
    }
}