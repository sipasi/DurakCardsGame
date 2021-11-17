
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
            IPlayer first = PlayerTool.DefineFirstPlayerBySmallestTrump(playerStorage.Entity.Active, deck.Entity.Bottom);

            Debug.Log(nameof(BattleFirstStartState));

            playerQueue.Entity.Set(
                attacker: first,
                defender: playerQueue.Entity.GetNextFrom(first),
                action: PlayerActionType.Attack);

            Debug.Log($"Attacker: {playerQueue.Entity.Attacker.Name}, Defender: {playerQueue.Entity.Defender.Name}");
        }
    }
}