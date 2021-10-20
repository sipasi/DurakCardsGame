
using ProjectCard.DurakModule.HandlerModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class PlayerActionState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Handlers")]
        [SerializeField] private CardSelectionHandler selectionHandler;
        [SerializeField] private PassSelectionHandler passSelectionHandler;

        [Header("Events")]
        [SerializeField] private ScriptableAction<PlayerInfo, ICard> cardSelected;
        [SerializeField] private ScriptableAction<PlayerInfo> passAction;

        private PlayerInfo current;

        public override void Enter()
        {
            base.Enter();

            cardSelected.Action += OnCardSelected;
            passAction.Action += OnPass;

            current = playerQueue.Current;

            CardSelector selector = current.Selector;

            selector.Begin();
        }
        public override void Exit()
        {
            base.Exit();

            cardSelected.Action -= OnCardSelected;
            passAction.Action -= OnPass;

            CardSelector selector = current.Selector;

            selector.End();

            current = null;
        }

        private async void OnCardSelected(PlayerInfo player, ICard card)
        {
            if (await selectionHandler.Handle(card) is false)
            {
                return;
            }

            machine.Fire(DurakGameState.PlayerAction);
        }
        private void OnPass(PlayerInfo player)
        {
            if (passSelectionHandler.Handle() is false) return;

            machine.Fire(DurakGameState.BattleEnd);
        }
    }
}