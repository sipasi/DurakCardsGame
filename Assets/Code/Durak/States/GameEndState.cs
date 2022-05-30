using Framework.Durak.Ui.Windows.Dialogs;
using Framework.Durak.Services.Scenes;
using Framework.Shared.Services.Scenes;
using Framework.Shared.States;
using Framework.Shared.UI.Windows.Dialogs;

using System;

namespace Framework.Durak.States
{
    public class GameEndState : DurakState
    {
        private readonly IMainMenuLoader mineMenu;

        private readonly IGameEndDialogWindow dialog;

        public GameEndState(IStateMachine<DurakGameState> machine, IMainMenuLoader mineMenu, IGameEndDialogWindow dialog)
            : base(machine)
        {
            this.mineMenu = mineMenu;
            this.dialog = dialog;
        }

        public override async void Enter()
        {
            base.Enter();

            var result = await dialog.Show();

            if (result is DialogResult.Ok)
            {
                NextState(DurakGameState.GameRestart);
            }
            else if (result is DialogResult.Cancel)
            {
                await mineMenu.Load();
            }
        }
    }
}