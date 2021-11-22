
using System;

using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.SaveModule;
using ProjectCard.Shared.GameModule;
using ProjectCard.Shared.SaveModule;
using ProjectCard.Shared.ServiceModule.SaveModule;
using ProjectCard.Shared.ServiceModule.SceneModule;
using ProjectCard.Shared.WindowModule;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectCard.Shared.SceneModule
{
    public class GameSceneLoader : MonoBehaviour
    {
        [Header("Ui")]
        [SerializeField] private DialogWindow loadSavedGameDialog;
        [Header("Save")]
        [SerializeField] private GuidSaveService saveService;
        [SerializeField] private SaveKey saveInfoKey;

        [Header("Load")]
        [SerializeField] private GameLoadProperties loadProperties;

        [Header("Scnes")]
        [SerializeField] private SceneLoadingService sceneLoadingService;
        [SerializeField] private SceneReference loadScreenScene;
        [SerializeField] private SceneReference gameScene;

        public async void Load()
        {
            await saveService.LoadStorage();

            var result = await ShowMessageIfSaveContains();

            loadProperties.LoadType = result == DialogResult.Ok
                ? GameLoadType.Saved
                : GameLoadType.New;

            await sceneLoadingService.Load(loadScreenScene.ScenePath, LoadSceneMode.Single);

            var background = await sceneLoadingService.LoadInBackground(gameScene.ScenePath, LoadSceneMode.Single);

            await UniTask.Delay(1000);

            background.Activate();
        }
        private async UniTask<DialogResult> ShowMessageIfSaveContains()
        {
            Guid key = saveInfoKey.Key;

            if (saveService.Contains(key) is false)
            {
                return DialogResult.Cancel;
            }

            SaveInfo save = saveService.Restore<SaveInfo>(key);

            IDialogWindowProperties properties = loadSavedGameDialog.Propeties;

            properties.Message = $"Do you want to load saved game\nTitle: {save.Title}\nLast played: {save.Created}";

            return await loadSavedGameDialog.Show();
        }
    }
}
