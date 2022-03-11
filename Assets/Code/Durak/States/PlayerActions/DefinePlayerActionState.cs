using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States.Actions
{
    public class DefinePlayerActionState : DurakState
    {
        private readonly IPlayerQueue<IPlayer> queue;

        public DefinePlayerActionState(IStateMachine<DurakGameState> machine, IPlayerQueue<IPlayer> queue)
            : base(machine)
        {
            this.queue = queue;
        }

        public override void Enter()
        {
            base.Enter();

            DurakGameState state = queue.IsAttackerQueue
                ? DurakGameState.PlayerAttacking
                : DurakGameState.PlayerDefending;

            NextState(state);
        }
    }
}