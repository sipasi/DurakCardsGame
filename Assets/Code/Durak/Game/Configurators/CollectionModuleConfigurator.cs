using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Game.EntityCreators;
using Framework.Durak.Players;
using Framework.Durak.Rules.Scriptables;
using Framework.Durak.Saves;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Game.Configurators
{
    [Serializable]
    internal class CollectionModuleConfigurator : MonoBehaviour, INewGameConfigurator, ISavedGameConfigurator
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Installers")]
        [SerializeField] private CardListCreator cardListCreator;
        [SerializeField] private PlayerListCreator playerListCreator;
        [SerializeField] private PlacesCreator placesCreator;

        void INewGameConfigurator.Configure(ServiceBuilder builder)
        {
            IReadOnlyList<Data> datas = DataCreator.Create(size.Suits, size.Ranks);

            IReadOnlyList<ICard> cards = cardListCreator.Create(size);

            Assert.AreEqual(datas.Count, cards.Count);

            IDeck<Data> deck = new Deck<Data>(datas);

            IBoard<Data> board = new Board<Data>(rowItemsCount: 6);

            IPlaces<Transform> places = placesCreator.Create();

            IDiscardPile discard = new DiscardPile();

            IMap<ICard, Data> cardMap = new Map<ICard, Data>(cards, datas);

            var (players, placeMap) = playerListCreator.Create();

            IPlayerStorage<IPlayer> storage = new PlayerStorage<IPlayer>(players);
            IPlayerQueue<IPlayer> queue = new PlayerQueue<IPlayer>(storage);

            Dependencies dependencies = new()
            {
                Datas = datas,
                Deck = deck,
                Board = board,
                Discard = discard,
                Places = places,
                CardMap = cardMap,
                PlaceMap = placeMap,
                Storage = storage,
                Queue = queue,
            };

            dependencies.Set(builder);
        }
        void ISavedGameConfigurator.Configure(ServiceBuilder builder, SaveData data)
        {
            IReadOnlyList<ICard> cards = cardListCreator.Create(size);

            PlayerStorage<IPlayer> storage = new(data.AllPlayers);

            var removed = storage.All.Where(player => data.RemovedPlayers.Contains(player.Id));

            storage.RemoveRange(removed);

            IPlayer attaker = storage.Active.First(player => player.Id == data.Attaker);
            IPlayer defender = storage.Active.First(player => player.Id == data.Defender);

            PlayerQueue<IPlayer> queue = new(storage);

            if (data.GameState is States.DurakGameState.PlayerAttacking or States.DurakGameState.Toss)
            {
                queue.SetAttackerQueue(attaker, defender);
            }
            else if (data.GameState is States.DurakGameState.PlayerDefending)
            {
                queue.SetDefenderQueue(attaker, defender);
            }

            Dependencies dependencies = new()
            {
                Datas = data.Datas,
                Deck = data.Deck,
                Board = data.Board,
                Discard = data.DiscardPile,
                Places = placesCreator.Create(),
                CardMap = new Map<ICard, Data>(cards, data.Datas),
                PlaceMap = playerListCreator.CreateMap(),
                Storage = storage,
                Queue = queue,
            };

            dependencies.Set(builder);
        }

        private struct Dependencies
        {
            public IReadOnlyList<Data> Datas { get; set; }
            public IDeck<Data> Deck { get; set; }
            public IBoard<Data> Board { get; set; }
            public IDiscardPile Discard { get; set; }
            public IPlaces<Transform> Places { get; set; }
            public IMap<ICard, Data> CardMap { get; set; }
            public IMap<Place, ICardOwner> PlaceMap { get; set; }
            public IPlayerStorage<IPlayer> Storage { get; set; }
            public IPlayerQueue<IPlayer> Queue { get; set; }

            public readonly void Set(ServiceBuilder builder)
            {
                builder.singleton
                    .Add(Datas)
                    .Add(Deck)
                    .Add(Board)
                    .Add(Places)
                    .Add(Discard)
                    .Add(CardMap)
                    .Add(PlaceMap)
                    .Add(Storage)
                    .Add(Queue);
            }
        }
    }
}