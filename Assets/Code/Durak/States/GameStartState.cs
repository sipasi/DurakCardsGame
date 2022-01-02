using Framework.Durak.Entities;
using Framework.Durak.Views;

using UnityEngine;

namespace Framework.Durak.States
{
    public class GameStartState : DurakState
    {
        [Header("Entities")]
        [SerializeField] private DeckEntity deck;

        [Header("View")]
        [SerializeField] private DeckViewUpdater viewUpdater;

        public override void Enter()
        {
            base.Enter();

            deck.Value.Shuffle(times: 500);

            viewUpdater.UpdateSprites();
            viewUpdater.UpdateCount();

            NextState(DurakGameState.BattleFirstStart);
        }
    }
}