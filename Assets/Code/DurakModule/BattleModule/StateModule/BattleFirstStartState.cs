
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.GameplayModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;

using UnityEngine;


namespace ProjectCard.DurakModule.BattleModule.StateModule
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

            NextState(DurakGameState.PlayerAction);
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