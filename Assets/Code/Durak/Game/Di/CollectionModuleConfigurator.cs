using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Rules.Scriptables;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class CollectionModuleConfigurator
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
        [SerializeField] private EntityPlaceTransformMapCreator entityPlaceTransformMapCreator;

        public void Configure(ServiceBuilder builder)
        {
            Builder singleton = builder.singleton;

            IReadOnlyList<Data> datas = dataListCreator.Create();
            IReadOnlyList<ICard> cards = cardListCreator.Create();

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
            IMap<EntityPlace, EntityPlaceTransformGetter> entityPlaceMap = entityPlaceTransformMapCreator.Create(places);

            singleton
                .Add(cardMap)
                .Add(deck)
                .Add(board)
                .Add(places)
                .Add(discard)
                .Add(playerMap)
                .Add(storage)
                .Add(queue)
                .Add(entityPlaceMap);
        }
    }
}