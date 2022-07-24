
using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.States.Actions
{
    public abstract class PlayerActionState : DurakState
    {
        private readonly int aiWaitDelay = 200;

        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IPlayerStorage<IPlayer> storage;
        private readonly IPlayerQueue<IPlayer> queue;

        private readonly IReadonlyIndexer<PlayerType, ISelectorsGroup> selectorsIndexer;
        private readonly ICardSelectionHandler selection;

        protected abstract DurakGameState AfterCardSelected { get; }
        protected abstract DurakGameState AfterPass { get; }

        protected IPlayer Current { get; private set; }

        protected PlayerActionState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlayerStorage<IPlayer> storage, IPlayerQueue<IPlayer> queue, IReadonlyIndexer<PlayerType, ISelectorsGroup> selectorsIndexer, ICardSelectionHandler selection)
            : base(machine)
        {
            this.deck = deck;
            this.board = board;
            this.storage = storage;
            this.queue = queue;
            this.selectorsIndexer = selectorsIndexer;
            this.selection = selection;
        }

        public sealed override async void Enter()
        {
            base.Enter();

            UpdatePlayerQueue(queue);

            Current = queue.Current;

            IPlayer player = Current;

            if (player.Type == PlayerType.Ai)
            {
                await UniTask.Delay(aiWaitDelay);
            }

            Log(player, action: nameof(Enter), result: true);

            StartListener();
        }
        public sealed override void Exit()
        {
            base.Exit();

            EndListener();

            Current = null;
        }

        protected abstract ICardSelector GetSelector(ISelectorsGroup group);

        protected abstract void UpdatePlayerQueue(IPlayerQueue<IPlayer> entity);

        private void StartListener()
        {
            IPlayer player = Current;

            ISelectorsGroup group = selectorsIndexer[player.Type];

            ICardSelector selector = GetSelector(group);

            selector.Selected += OnCardSelected;
            selector.Passed += OnPass;

            selector.Begin(player);
        }
        private void EndListener()
        {
            IPlayer player = Current;

            ISelectorsGroup group = selectorsIndexer[player.Type];

            ICardSelector selector = GetSelector(group);

            selector.Selected -= OnCardSelected;
            selector.Passed -= OnPass;

            selector.End(player);
        }

        private async void OnCardSelected(IPlayer player, ICard card)
        {
            if (await selection.Handle(card) is false)
            {
                Log(Current, action: nameof(OnCardSelected), result: false);

                return;
            }

            Log(Current, action: nameof(OnCardSelected), result: true);

            NextState(AfterCardSelected);
        }
        private void OnPass(IPlayer player)
        {
            if (board.IsEmpty)
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