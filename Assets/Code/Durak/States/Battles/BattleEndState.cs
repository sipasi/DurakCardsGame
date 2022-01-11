using Framework.Durak.Entities;
using Framework.Durak.Players;

using UnityEngine;

namespace Framework.Durak.States.Battles
{
    public class BattleEndState : DurakState
    {
        [Header("Entities")]
        [SerializeField] private DeckEntity deck;
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;

        public override void Enter()
        {
            base.Enter();

            if (deck.Value.IsEmpty)
            {
                playerStorage.EliminateEmpty();

                if (playerStorage.Value.Active.Count < 2)
                {
                    NextState(DurakGameState.GameEnd);

                    return;
                }
            }

            NextState(DurakGameState.BattleStart);
        }
    }
}