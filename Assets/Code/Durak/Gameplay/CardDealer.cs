using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Rules;
using Framework.Durak.Services.Movements;
using Framework.Durak.Ui.Views;
using Framework.Shared.Collections;

namespace Framework.Durak.Gameplay
{
    public class CardDealer : ICardDealer
    {
        private readonly IDeck<Data> deck;
        private readonly IDeckUi deckUi;
        private readonly IPlayerStorage<IPlayer> storage;

        private readonly IDurakRules rules;
        private readonly IDataMovementService movement;

        public CardDealer(IDeck<Data> deck, IDeckUi deckUi, IPlayerStorage<IPlayer> storage, IDurakRules rules, IDataMovementService movement)
        {
            this.deck = deck;
            this.deckUi = deckUi;
            this.storage = storage;
            this.rules = rules;
            this.movement = movement;
        }

        public async UniTask DealCard()
        {
            foreach (var player in storage.Active)
            {
                foreach (var data in Dealer.DealCards(deck, player.Hand, rules.MaxCardsInHand))
                {
                    player.Hand.Add(data);

                    deckUi.UpdateCount();

                    await movement.MoveToPlace(data, player.Owner, player.Hand.LookSide);
                }
            }
        }
    }
}