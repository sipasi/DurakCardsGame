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
            IReadonlyPlayer first = PlayerTool.DefineFirstPlayerBySmallestTrump(playerStorage.GetReadonlyPlayers(), deck.Value.Bottom);

            Debug.Log(nameof(BattleFirstStartState));

            var queue = playerQueue.Value;

            playerQueue.SetAttackerQueue(
                attacker: first,
                defender: queue.GetNextFrom(first));

            Debug.Log($"Attacker: {playerQueue.Value.Attacker.Value.Name}, Defender: {playerQueue.Value.Defender.Value.Name}");
        }
    }
}