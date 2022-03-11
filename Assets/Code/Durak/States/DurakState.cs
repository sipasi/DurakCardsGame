using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.States
{
    public abstract class DurakState : IState
    {
        private readonly IStateMachine<DurakGameState> machine;

        protected DurakState(IStateMachine<DurakGameState> machine)
        {
            this.machine = machine;
        }

        public virtual void Enter()
        {
            Debug.Log($"{nameof(Enter)}: {GetType().Name}");
        }
        public virtual void Exit()
        {
            //Debug.Log($"{nameof(Exit)}: {GetType().Name}");
        }

        protected void NextState(DurakGameState state) => machine.Fire(state);
    }
}