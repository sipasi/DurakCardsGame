using Framework.Durak.Gameplay;
using Framework.Shared.States;

using UnityEngine;


namespace Framework.Durak.States.Battles
{
    public class BattleStartState : DurakState
    {
        private readonly ICardDealer dealer;

        public BattleStartState(IStateMachine<DurakGameState> machine, ICardDealer dealer)
            : base(machine)
        {
            this.dealer = dealer;
        }

        public override async void Enter()
        {
            base.Enter();

            await dealer.DealCard();

            Debug.Log(nameof(BattleStartState));

            NextState(DurakGameState.PlayerAttacking);
        }
    }
}