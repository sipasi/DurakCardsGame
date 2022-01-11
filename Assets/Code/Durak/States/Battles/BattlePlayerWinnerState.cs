
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Entities;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.States.Battles
{
    public abstract class BattlePlayerWinnerState : DurakState
    {
        [Header(nameof(BattlePlayerWinnerState))]

        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Shared")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;

        public sealed override async void Enter()
        {
            IReadOnlyList<Data> all = board.Value.All;

            await MoveCards(all);

            UpdatePlayerQueue(playerQueue);

            board.Clear();

            NextState(DurakGameState.BattleEnd);
        }

        protected abstract UniTask MoveCards(IReadOnlyList<Data> datas);
        protected abstract void UpdatePlayerQueue(IPlayerQueueEntity entity);
    }
}