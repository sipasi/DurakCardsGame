
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.HandlerModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class OneAttackerTossState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;
        [SerializeField] private PlayerSelectorList playerSelectorList;

        [Header("Handlers")]
        [SerializeField] private TossCardSelectionHandler selectionHandler;
        [SerializeField] private PassSelectionHandler passSelectionHandler;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;

        [Header("Validators")]
        [SerializeField] private PassValidator passValidator;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        IPlayer current;

        public override void Enter()
        {
            base.Enter();

            cardSelected.Action += OnCardSelected;
            passAction.Action += OnPass;

            playerQueue.Entity.Set(
                attacker: playerQueue.Entity.Attacker,
                defender: playerQueue.Entity.Defender,
                action: PlayerActionType.Attack);

            current = playerQueue.Entity.Attacker;

            ICardSelector selector = playerSelectorList.Get(current.Selector);

            selector.Begin();
        }
        public override void Exit()
        {
            base.Exit();

            cardSelected.Action -= OnCardSelected;
            passAction.Action -= OnPass;

            ICardSelector selector = playerSelectorList.Get(current.Selector);

            selector.End();

            current = null;
        }

        private async void OnCardSelected(IPlayer player, ICard card)
        {
            if (await selectionHandler.Handle(card) is false)
            {
                return;
            }

            DurakGameState state = board.Entity.IsAttacksFull ? DurakGameState.BattleAttackerWinner : DurakGameState.Toss;

            NextState(state);
        }
        private void OnPass(IPlayer player)
        {
            if (passValidator.Validate() is false)
            {
                return;
            }

            passSelectionHandler.Handle();

            NextState(DurakGameState.BattleAttackerWinner);
        }
    }
}