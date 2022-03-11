using Framework.Durak.Datas;
using Framework.Durak.Gameplay;
using Framework.Durak.Players;
using Framework.Durak.Players.Tools;
using Framework.Shared.Collections;
using Framework.Shared.States;

using UnityEngine;


namespace Framework.Durak.States.Battles
{
    public class BattleFirstStartState : DurakState
    {
        private readonly IDeck<Data> deck;
        private readonly IPlayerStorage<IPlayer> storage;
        private readonly IPlayerQueue<IPlayer> queue;

        private readonly ICardDealer dealer;

        public BattleFirstStartState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IPlayerStorage<IPlayer> storage, IPlayerQueue<IPlayer> queue, ICardDealer dealer)
            : base(machine)
        {
            this.deck = deck;
            this.storage = storage;
            this.queue = queue;
            this.dealer = dealer;
        }

        public override async void Enter()
        {
            base.Enter();

            await dealer.DealCard();

            FirstBallte();

            NextState(DurakGameState.PlayerAttacking);
        }
        private void FirstBallte()
        {
            IPlayer first = PlayerTool.DefineFirstPlayerBySmallestTrump(storage.Active, deck.Bottom);

            Debug.Log(nameof(BattleFirstStartState));

            queue.SetAttackerQueue(
                attacker: first,
                defender: queue.GetNextFrom(first));

            Debug.Log($"Attacker: {queue.Attacker.Name}, Defender: {queue.Defender.Name}");
        }
    }
}