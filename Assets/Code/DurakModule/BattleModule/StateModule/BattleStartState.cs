
using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public class BattleStartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorage playerStorage;
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Gameplay")]
        [SerializeField] private CardDealer dealer;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattlesCountInfo info;
        [SerializeField] private BattleResultInfo result;


        public override async void Enter()
        {
            base.Enter();

            await dealer.DealCard();

            if (info.IsFirstBattle is true)
            {
                FirstBallte();
            }
            else
            {
                NextBattles();
            }

            result.Clear();


            machine.Fire(DurakGameState.PlayerAction);
        }

        private void FirstBallte()
        {
            Deck<Data> deck = shared.Deck;

            PlayerInfo first = PlayerTool.DefineFirstPlayerBySmallestTrump(playerStorage.Active, deck.Bottom);

            playerQueue.Set(
                attacker: first,
                defender: playerQueue.GetNextFrom(first),
                action: PlayerActionType.Attack);

            Debug.Log($"Attacker: {playerQueue.Attacker.Name}, Defender: {playerQueue.Defender.Name}");
        }

        private void NextBattles()
        {
            Assert.IsTrue(result.IsWinnerDefined, "Winner can't be undefined");

            if (result.IsAttackerWinner)
            {
                playerQueue.Set(
                    attacker: playerQueue.GetNextFrom(playerQueue.Defender),
                    defender: playerQueue.GetNextFrom(playerQueue.Defender, andSkip: 1),
                    action: PlayerActionType.Attack);

                return;
            }

            playerQueue.Set(
                attacker: playerQueue.Defender,
                defender: playerQueue.GetNextFrom(playerQueue.Defender),
                action: PlayerActionType.Attack);

            return;
        }
    }
}