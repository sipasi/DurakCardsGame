using System.Linq;
using System.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Game.DependencyInjection;
using Framework.Durak.Players;
using Framework.Durak.Saves;
using Framework.Durak.Services.Movements;
using Framework.Durak.States;
using Framework.Durak.Ui.Views;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Events;
using Framework.Shared.IO;
using Framework.Shared.Saves;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class SavedGameLoader : GameLoader
    {
        private SaveData data;

        public SavedGameLoader(ScriptableAction restart) : base(restart) { }

        protected override async ValueTask BeforeLoad()
        {
            LocalBinaryFile<SaveData> loader = new(SavePaths.durak.path);

            data = loader.Load();

            await Task.CompletedTask;
        }

        protected override ValueTask AfterLoad(IDiContainer container)
        {
            var deck = container.Get<IDeck<Data>>();
            var board = container.Get<IBoard<Data>>();
            var discard = container.Get<IDiscardPile>();

            var places = container.Get<IPlaces<Transform>>();

            var storage = container.Get<IPlayerStorage<IPlayer>>();

            var deckMovement = container.Get<IDeckCardMovement>();
            var boardMovement = container.Get<IBoardCardMovement>();
            var discardMovement = container.Get<IDiscardPileCardMovement>();
            var playerMovement = container.Get<IPlayerCardMovement>();

            var deckUi = container.Get<IDeckUi>();
            deckUi.UpdateTrump();
            deckUi.UpdateCount();


            deckMovement.Teleport(deck);

            foreach (var data in board)
            {
                if (board.Attacks.Contains(data))
                {
                    boardMovement.TeleportToAttacks(data);

                    continue;
                }

                boardMovement.TeleportToDefends(data);
            }

            discardMovement.Teleport(discard);

            foreach (var player in storage.Active)
            {
                playerMovement.Teleport(player, player.Hand);
            }

            return new(Task.CompletedTask);
        }

        protected override IDiContainer CreateDiContainer()
        {
            return DiContainerConfigurator.BuildForSavedGame(data);
        }

        protected override DurakGameState GetState() => data.GameState;
    }
}