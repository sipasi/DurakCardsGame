using Framework.Durak.Ui.Windows.Dialogs;
using Framework.Shared.States;
using Framework.Shared.UI.Windows.Dialogs;

namespace Framework.Durak.States
{
    public class GameEndState : DurakState
    {
        private readonly IGameEndDialogWindow dialog;

        public GameEndState(IStateMachine<DurakGameState> machine, IGameEndDialogWindow dialog)
            : base(machine)
        {
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

            }
        }
    }
}