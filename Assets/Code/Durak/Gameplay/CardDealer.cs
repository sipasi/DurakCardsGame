using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Rules;
using Framework.Durak.Services.Movements;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine;

namespace Framework.Durak.Gameplay
{
    public class CardDealer : ICardDealer
    {
        private readonly IDeck<Data> deck;
        private readonly IPlayerStorage<IPlayer> storage;

        private readonly IDurakRules rules;
        private readonly IMap<IPlayer, Transform> map;
        private readonly IDataMovementManager movement;

        public CardDealer(IDeck<Data> deck, IPlayerStorage<IPlayer> storage, IDurakRules rules, IMap<IPlayer, Transform> map, IDataMovementManager movement)
        {
            this.deck = deck;
            this.storage = storage;
            this.rules = rules;
            this.map = map;
            this.movement = movement;
        }

        public async UniTask DealCard()
        {
            foreach (var player in storage.Active)
            {
                foreach (var data in Dealer.DealCards(deck, player.Hand, rules.MaxCardsInHand))
                {
                    player.Hand.Add(data);

                    var transform = map.Get(player);

                    await movement.MoveToPlace(data, transform, player.Hand.LookSide);
                }
            }
        }
    }
}