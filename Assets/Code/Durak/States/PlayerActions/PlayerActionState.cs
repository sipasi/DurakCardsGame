
using Cysharp.Threading.Tasks;

using Framework.Durak.Cards.Selectors;
using Framework.Durak.Entities;
using Framework.Durak.Gameplay.Events;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Players;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Durak.States.Actions
{
    public abstract class PlayerActionState : DurakState
    {
        [Header("Players")]
        [SerializeField] private CardSelectorList selectors;
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Handlers")]
        [SerializeField] private CardSelectionHandlerBace selectionHandler;
        [SerializeField] private PassValidator passValidator;

        [Header("Time")]
        [SerializeField] private int aiWaitDelay;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        protected IReadonlyPlayer Current { get; private set; }
        protected abstract DurakGameState AfterCardSelected { get; }
        protected abstract DurakGameState AfterPass { get; }

        public sealed override async void Enter()
        {
            base.Enter();

            var queue = playerQueue.Value;

            if (queue.Current.Type == PlayerType.Ai)
            {
                await UniTask.Delay(aiWaitDelay);
            }

            UpdatePlayerQueue(playerQueue);

            var current = Current = queue.Current;

            Log(current, action: nameof(Enter), result: true);

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

        protected abstract void UpdatePlayerQueue(IPlayerQueueEntity entity);

        private async void OnCardSelected(IReadonlyPlayer player, ICard card)
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

        private static void Log(IReadonlyPlayer player, string action, bool result)
        {
            Debug.Log($"Player: {player.Name}. Action[{action}]: {result}");
        }
    }
}