using Framework.Durak.Entities;
using Framework.Durak.Gameplay;
using Framework.Durak.Players;
using Framework.Durak.Players.Tools;

using UnityEngine;


namespace Framework.Durak.States.Battles
{
    public class BattleFirstStartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Gameplay")]
        [SerializeField] private CardDealer dealer;

        [Header("Shared")]
        [SerializeField] private DeckEntity deck;

        public override async void Enter()
        {
            base.Enter();

            await dealer.DealCard();

            FirstBallte();

            NextState(DurakGameState.PlayerAttacking);
        }
        private void FirstBallte()
        {
            IPlayer first = PlayerTool.DefineFirstPlayerBySmallestTrump(playerStorage.Value.Active, deck.Value.Bottom);

            Debug.Log(nameof(BattleFirstStartState));

            playerQueue.Value.Set(
                attacker: first,
                defender: playerQueue.Value.GetNextFrom(first),
                action: PlayerActionType.Attack);

            Debug.Log($"Attacker: {playerQueue.Value.Attacker.Name}, Defender: {playerQueue.Value.Defender.Name}");
        }
    }
}