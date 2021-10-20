using System.Collections.Generic;

using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public class BattleEndState : DurakState
    {
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Players")]
        [SerializeField] private PlayerStorage playerStorage;
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Places")]
        [SerializeField] private Transform trash;

        [Header("Views")]
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattlesCountInfo info;
        [SerializeField] private BattleResultInfo result;

        public override async void Enter()
        {
            base.Enter();

            boardPlaces.Clear();

            Board<Data> board = shared.Board;

            Assert.IsTrue(result.IsWinnerDefined, "Winner cannot be undefined");

            IReadOnlyList<Data> all = board.All;

            if (result.IsAttackerWinner)
            {
                PlayerInfo defender = playerQueue.Defender;
                Transform place = defender.Transform;
                CardEntityDataStorage hand = defender.Hand;
                CardLookSide lookSide = defender.LookSide;

                hand.AddRange(all);

                await movement.MoveToPlace(all, place, lookSide);
            }
            else
            {
                await movement.MoveToPlace(all, trash, CardLookSide.Back);
            }

            board.Clear();

            info.IncreaseBattlesCount();

            if (shared.Deck.IsEmpty)
            {
                EmptyPlayersEliminator.EliminateAndUpdateQueue(playerStorage, playerQueue);

                if (playerStorage.Active.Count < 2)
                {
                    machine.Fire(DurakGameState.GameEnd);

                    return;
                }
            }

            machine.Fire(DurakGameState.BattleStart);
        }
    }
}