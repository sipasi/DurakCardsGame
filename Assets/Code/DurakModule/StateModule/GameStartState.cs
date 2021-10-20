
using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class GameStartState : DurakState
    {
        [Header("Shared")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattleMovementInfo movementInfo;
        [SerializeField] private BattlesCountInfo countInfo;
        [SerializeField] private BattleResultInfo resultInfo;

        [Header("Views")]
        [SerializeField] private ViewUpdater viewUpdater;

        public override void Enter()
        {
            base.Enter();

            movementInfo.Clear();
            countInfo.Clear();
            resultInfo.Clear();

            Deck<Data> deck = shared.Deck;

            deck.Shuffle(times: 5);
            viewUpdater.UpdateDeck();

            machine.Fire(DurakGameState.BattleStart);
        }
    }
}