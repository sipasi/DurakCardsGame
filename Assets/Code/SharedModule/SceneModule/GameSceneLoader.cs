
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.SaveModule;
using ProjectCard.Shared.GameModule;
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
        [SerializeField] private Button button;

        [Header("Save")]
        [SerializeField] private TypeSaveService saveService;

        [Header("Game")]
        [SerializeField] private GameLoader game;

        [Header("Scnes")]
        [SerializeField] private SceneLoadingService sceneLoadingService;
        [SerializeField] private SceneReference loadScreenScene;
        [SerializeField] private SceneReference gameScene;


        private void Awake()
        {
            button.onClick.AddListener(Load);
        }


        private async void Load()
        {
            button.onClick.RemoveListener(Load);

            await saveService.LoadStorage();

            var result = await ShowMessageIfSaveContains();

            await sceneLoadingService.Load(loadScreenScene.ScenePath, LoadSceneMode.Single);

            var background = await sceneLoadingService.LoadInBackground(gameScene.ScenePath, LoadSceneMode.Single);

            UniTask loading = result == DialogResult.Ok
                ? game.LoadSavedGame()
                : game.LoadNewGame();

            await loading;

            background.Activate();
        }
        private async UniTask<DialogResult> ShowMessageIfSaveContains()
        {
            if (saveService.Contains<SaveInfo>() is false)
            {
                return DialogResult.Cancel;
            }

            SaveInfo save = saveService.Restore<SaveInfo>();

            IDialogWindowProperties properties = loadSavedGameDialog.Propeties;

            properties.Message = $"Do you want to load saved game\nTitle: {save.Title}\nLast played: {save.Created}";

            return await loadSavedGameDialog.Show();
        }
    }
}
