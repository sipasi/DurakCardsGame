
using Framework.Shared.Scenes;
using Framework.Shared.Services.Scenes;
using Framework.Shared.UI.Windows.Dialogs;

using UnityEngine;

namespace Framework.Durak.States
{
    public class GameEndState : DurakState
    {
        [Header("Window")]
        [SerializeField] private DialogWindow gameRestartDialogWindow;

        [Header("Scene")]
        [SerializeField] private SceneLoadingService sceneLoadingService;
        [SerializeField] private SceneReference mainMenu;

        public override async void Enter()
        {
            base.Enter();

            var result = await gameRestartDialogWindow.Show();

            if (result is DialogResult.Ok)
            {
                NextState(DurakGameState.GameRestart);
            }
            else if (result is DialogResult.Cancel)
            {
                await sceneLoadingService.Load(mainMenu);
            }
        }
    }
}