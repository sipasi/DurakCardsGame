
using Cysharp.Threading.Tasks;

using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.HandlerModule;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Durak.ValidatorModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;
using ProjectCard.Shared.ScriptableModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule
{
    public abstract class PlayerActionState : DurakState
    {
        [Header("Players")]
        [SerializeField] private CardSelectorList selectors;
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Handlers")]
        [SerializeField] private CardSelectionHandlerBace selectionHandler;
        [SerializeField] private PassValidator passValidator;

        [Header("TimeDelay")]
        [SerializeField] private int delay;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        protected IPlayer Current { get; private set; }
        protected abstract DurakGameState AfterCardSelected { get; }
        protected abstract DurakGameState AfterPass { get; }

        public sealed override async void Enter()
        {
            base.Enter();

            if (playerQueue.Value.Current.Type == PlayerType.Ai)
            {
                await UniTask.Delay(delay);
            }

            UpdatePlayerQueue(playerQueue.Value);

            var current = Current = playerQueue.Value.Current;

            Log(Current, action: nameof(Enter), result: true);

            cardSelected.Action += OnCardSelected;
            passAction.Action += OnPass;

            IPlayerCardSelection playerCardSelection = selectors.Get(current.Type);

            ICardSelector selector = GetSelector(playerCardSelection);

            selector.Begin(current);
        }
        public sealed override void Exit()
        {
            base.Exit();

            var current = Current;

            cardSelected.Action -= OnCardSelected;
            passAction.Action -= OnPass;

            IPlayerCardSelection playerCardSelection = selectors.Get(current.Type);

            ICardSelector selector = GetSelector(playerCardSelection);

            selector.End(Current);

            Current = null;
        }

        protected abstract ICardSelector GetSelector(IPlayerCardSelection selection);

        protected abstract void UpdatePlayerQueue(IPlayerQueue queue);

        private async void OnCardSelected(IPlayer player, ICard card)
        {
            if (await selectionHandler.Handle(card) is false)
            {
                Log(Current, action: nameof(OnCardSelected), result: false);

                return;
            }

            Log(Current, action: nameof(OnCardSelected), result: true);

            NextState(AfterCardSelected);
        }
        private void OnPass(IPlayer player)
        {
            if (passValidator.Validate() is false)
            {
                Log(Current, action: nameof(OnPass), result: false);

                return;
            }

            Log(Current, action: nameof(OnPass), result: true);

            NextState(AfterPass);
        }

        private static void Log(IPlayer player, string action, bool result)
        {
            Debug.Log($"Player: {player.Name}. Action[{action}]: {result}");
        }
    }
}