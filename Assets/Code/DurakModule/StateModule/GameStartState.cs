
using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
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

            deck.Entity.Shuffle(times: 500);

            viewUpdater.UpdateSprites();
            viewUpdater.UpdateCount();

            NextState(DurakGameState.BattleFirstStart);
        }
    }
}