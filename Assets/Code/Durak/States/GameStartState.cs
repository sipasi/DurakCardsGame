using ProjectCard.Durak.EntityModule; 
using ProjectCard.Durak.ViewModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule
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