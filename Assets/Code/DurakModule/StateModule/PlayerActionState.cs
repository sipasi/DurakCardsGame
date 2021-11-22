
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.HandlerModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class PlayerActionState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;
        [SerializeField] private PlayerSelectorList playerSelectorList;

        [Header("Handlers")]
        [SerializeField] private CardSelectionHandler selectionHandler;
        [SerializeField] private PassSelectionHandler passSelectionHandler;

        [Header("Views")]
        [SerializeField] private BoardPlaces places;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        private IPlayer current;

        public override void Enter()
        {
            base.Enter();

            cardSelected.Action += OnCardSelected;
            passAction.Action += OnPass;

            current = playerQueue.Value.Current;

            ICardSelector selector = playerSelectorList.Get(current.Selector);

            selector.Begin(current);
        }
        public override void Exit()
        {
            base.Exit();

            cardSelected.Action -= OnCardSelected;
            passAction.Action -= OnPass;

            ICardSelector selector = playerSelectorList.Get(current.Selector);

            selector.End(current);

            current = null;
        }

        private async void OnCardSelected(IPlayer player, ICard card)
        {
            if (await selectionHandler.Handle(card) is false)
            {
                return;
            }

            playerQueue.Value.SwitchActionType();

            NextState(DurakGameState.PlayerAction);
        }
        private void OnPass(IPlayer player)
        {
            if (passSelectionHandler.Handle() is false) return;

            DurakGameState state = playerQueue.Value.IsAttackerQueue
                ? DurakGameState.BattleDefenderWinner
                : DurakGameState.Toss;

            NextState(state);
        }
    }
}