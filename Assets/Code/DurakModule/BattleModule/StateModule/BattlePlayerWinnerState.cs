
using ProjectCard.DurakModule.CardModule;
using System.Collections.Generic;

using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;

using UnityEngine;
using ProjectCard.DurakModule.ViewModule;
using Cysharp.Threading.Tasks;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public abstract class BattlePlayerWinnerState : DurakState
    {
        [Header(nameof(BattlePlayerWinnerState))]
        [Header("Views")]
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Shared")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;

        public sealed override async void Enter()
        {
            IReadOnlyList<Data> all = board.Entity.All;

            await MoveCards(all);

            UpdatePlayerQueue(playerQueue.Entity);

            boardPlaces.Clear();
            board.Entity.Clear();

            if (deck.Entity.IsEmpty)
            {
                EmptyPlayersEliminator.EliminateAndUpdateQueue(playerStorage.Entity, playerQueue.Entity);

                if (playerStorage.Entity.Active.Count < 2)
                {
                    NextState(DurakGameState.GameEnd);

                    return;
                }
            }

            NextState(DurakGameState.BattleEnd);
        }

        protected abstract UniTask MoveCards(IReadOnlyList<Data> datas);
        protected abstract void UpdatePlayerQueue(IPlayerQueue playerQueue);
    }
}