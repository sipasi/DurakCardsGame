using Framework.Shared.Scenes;
using Framework.Shared.Services.Scenes;
using Framework.Shared.States;
using Framework.Shared.UI.Windows.Dialogs;

using System;

namespace Framework.Durak.States
{
    public class GameEndState : DurakState
    {
        private readonly ISceneLoadingService sceneLoadingService;

        private readonly DialogWindow gameRestartDialogWindow;

        private readonly SceneReference mainMenu;

        public GameEndState(IStateMachine<DurakGameState> machine, ISceneLoadingService sceneLoadingService)
            : base(machine)
        {
            this.sceneLoadingService = sceneLoadingService;
        }


        public override async void Enter()
        {
            base.Enter();

            throw new NotImplementedException();

            //var result = await gameRestartDialogWindow.Show();

            //if (result is DialogResult.Ok)
            //{
            //    NextState(DurakGameState.GameRestart);
            //}
            //else if (result is DialogResult.Cancel)
            //{
            //    await sceneLoadingService.Load(mainMenu);
            //}
        }
    }
}