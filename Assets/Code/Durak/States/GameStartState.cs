using Framework.Durak.Datas;
using Framework.Durak.Ui.Views;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States
{
    public class GameStartState : DurakState
    {
        private readonly IDeck<Data> deck;
        private readonly IDeckUi deckUi;

        public GameStartState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IDeckUi deckUi)
            : base(machine)
        {
            this.deck = deck;
            this.deckUi = deckUi;
        }

        public override void Enter()
        {
            base.Enter();

            deck.Shuffle(times: 500);

            deckUi.UpdateTrump();
            deckUi.UpdateCount();

            NextState(DurakGameState.BattleFirstStart);
        }
    }
}