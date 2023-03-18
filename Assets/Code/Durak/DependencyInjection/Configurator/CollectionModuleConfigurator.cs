using System;
using System.Collections.Generic;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.DependencyInjection.Creators;
using Framework.Durak.Players;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection; 

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class CollectionModuleConfigurator : MonoBehaviour, IConfigurator
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Installers")]
        [SerializeField] private DataListCreator dataListCreator;
        [SerializeField] private CardListCreator cardListCreator;
        [SerializeField] private PlayerListCreator playerListCreator;
        [SerializeField] private CardMapCreator cardMapCreator;
        [SerializeField] private PlacesCreator placesCreator;

        public void Configure(ServiceBuilder builder)
        {
            Builder singleton = builder.singleton;

            IReadOnlyList<Data> datas = dataListCreator.Create(size);
            IReadOnlyList<ICard> cards = cardListCreator.Create(size);

            Assert.AreEqual(datas.Count, cards.Count);

            IDeck<Data> deck = new Deck<Data>(datas);

            IBoard<Data> board = new Board<Data>(rowItemsCount: 6);

            IPlaces<Transform> places = placesCreator.Create();

            IDiscardPile discard = new DiscardPile();

            playerListCreator.Create(out IReadOnlyList<IPlayer> players, out IMap<Place, ICardOwner> placeMap);

            IPlayerStorage<IPlayer> storage = new PlayerStorage<IPlayer>(players);
            IPlayerQueue<IPlayer> queue = new PlayerQueue<IPlayer>(storage);

            IMap<ICard, Data> cardMap = cardMapCreator.Create(cards, datas);

            singleton
                .Add(datas)
                .Add(deck)
                .Add(board)
                .Add(places)
                .Add(discard)
                .Add(cardMap)
                .Add(placeMap)
                .Add(storage)
                .Add(queue);
        }
    }
}