using Framework.Durak.Datas;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States
{
    public class GameStartState : DurakState
    {
        private readonly IDeck<Data> deck;

        public GameStartState(IStateMachine<DurakGameState> machine, IDeck<Data> deck)
            : base(machine)
        {
            this.deck = deck;
        }

        public override void Enter()
        {
            base.Enter();

            deck.Shuffle(times: 500);

            NextState(DurakGameState.BattleFirstStart);
        }
    }
}