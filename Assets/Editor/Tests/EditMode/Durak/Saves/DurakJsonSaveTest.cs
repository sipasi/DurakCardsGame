using System;
using System.IO;
using System.Linq;

using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.IO;

using NUnit.Framework;

using UnityEngine;

namespace Framework.Durak.Saves
{
    public class DurakJsonSaveTest
    {
        [Test]
        public void SaveDataSerializeDeSerialize()
        {
            string path = Path.Combine(Application.persistentDataPath, "Test", "Framework.Durak.Saves", "test.save");

            ISaveEntities entities = CreateSaveEntities();

            LocalBinaryFile<SaveData> file = new(path);

            SaveEntitiesMapper mapper = new(entities);

            SaveData metadata = mapper.Map();

            bool saveResult = file.Save(metadata);

            Assert.IsTrue(saveResult);

            SaveData loadedData = file.Load();

            AssertOriginAndLoadedData(entities, loadedData);
        }

        private static ISaveEntities CreateSaveEntities()
        {
            Data[] datas = Enumerable.Range(0, 52)
                .Select(index => new Data(suit: index % 4, rank: index % 13))
                .OrderBy(data => data.suit)
                .ThenBy(data => data.rank)
                .ToArray();

            Deck<Data> deck = new(datas);

            Board<Data> board = new(6);

            DiscardPile discardPile = new();

            for (int i = 0; i < 12; i++)
            {
                deck.TryPop(out Data data);

                board.Add(data);
            }

            for (int i = 0; i < 10; i++)
            {
                deck.TryPop(out Data data);

                discardPile.Add(data);
            }

            Player[] players = Enumerable.Range(0, 2)
                .Select(index =>
                {
                    var player = new Player
                    {
                        Id = System.Guid.Empty,
                        Type = PlayerType.Real,
                        Name = $"Player {index}",
                        Hand = new Hand(CardLookSide.Face)
                    };

                    for (int i = 0; i < 6; i++)
                    {
                        deck.TryPop(out Data data);

                        player.Hand.Add(data);
                    }

                    return player;
                })
                .ToArray();

            PlayerStorage<IPlayer> storage = new(players);
            PlayerQueue<IPlayer> queue = new(storage);

            queue.SetAttackerQueue(storage.Active[0], storage.Active[1]);

            TestSaveEntities save = new()
            {
                Datas = datas,
                Deck = deck,
                Board = board,
                DiscardPile = discardPile,

                Queue = queue,
                Storage = storage,
                TriggerInfo = new PlayerAttackingTriggerInfo()
            };

            return save;
        }

        private static void AssertOriginAndLoadedData(ISaveEntities origin, SaveData loaded)
        {
            Assert.IsNotNull(loaded);

            Assert.AreEqual(origin.Datas.Count, loaded.Datas.Count);

            Assert.AreEqual(origin.Deck.Count, loaded.Deck.Count);
            Assert.AreEqual(origin.Board.Count, loaded.Board.Count);
            Assert.AreEqual(origin.DiscardPile.Count, loaded.DiscardPile.Count);

            Assert.AreEqual(origin.Storage.Active.Count, loaded.ActivePlayers.Count);

            int totalCards = loaded.Deck.Count + loaded.Board.Count + loaded.DiscardPile.Count + loaded.AllPlayers.Sum(player => player.Hand.Count);

            Assert.AreEqual(origin.Datas.Count, totalCards);

            origin.Deck.SequenceEqual(loaded.Deck);
            origin.Board.SequenceEqual(loaded.Board);
            origin.DiscardPile.SequenceEqual(loaded.DiscardPile);

            Assert.IsNotNull(loaded.ActivePlayers.FirstOrDefault(player => player == loaded.Attaker));
            Assert.IsNotNull(loaded.ActivePlayers.FirstOrDefault(player => player == loaded.Defender));
        }
    }
}