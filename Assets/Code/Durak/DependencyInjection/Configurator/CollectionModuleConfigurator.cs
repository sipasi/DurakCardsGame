using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.DependencyInjection.Creators;
using Framework.Durak.Players;
using Framework.Durak.Rules.Scriptables;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class CollectionModuleConfigurator : ServiceConfigurator
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Installers")]
        [SerializeField] private DataListCreator dataListCreator;
        [SerializeField] private CardListCreator cardListCreator;
        [SerializeField] private PlayerListCreator playerListCreator;
        [SerializeField] private PlayerPlacesCreator playerPlacesCreator;
        [SerializeField] private CardMapCreator cardMapCreator;
        [SerializeField] private PlacesCreator placesCreator;

        public override void Configure(ServiceBuilder builder)
        {
            Builder singleton = builder.singleton;

            IReadOnlyList<Data> datas = dataListCreator.Create(size);
            IReadOnlyList<ICard> cards = cardListCreator.Create(size);

            Assert.AreEqual(datas.Count, cards.Count);

            IDeck<Data> deck = new Deck<Data>(datas);

            IBoard<Data> board = new Board<Data>(6);

            IPlaces<Transform> places = placesCreator.Create();

            IDiscardPile discard = new DiscardPile();

            IReadOnlyList<IPlayer> players = playerListCreator.Create();
            IReadOnlyList<Transform> playerPlaces = playerPlacesCreator.Create();

            Assert.AreEqual(players.Count, playerPlaces.Count);

            IPlayerStorage<IPlayer> storage = new PlayerStorage<IPlayer>(players);
            IPlayerQueue<IPlayer> queue = new PlayerQueue<IPlayer>(storage);

            IMap<ICard, Data> cardMap = cardMapCreator.Create(cards, datas);
            IMap<IPlayer, Transform> playerMap = new Map<IPlayer, Transform>(players, playerPlaces);

            singleton
                .Add(cardMap)
                .Add(deck)
                .Add(board)
                .Add(places)
                .Add(discard)
                .Add(playerMap)
                .Add(storage)
                .Add(queue);
        }
    }
}