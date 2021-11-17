using System;
using System.Collections.Generic;
using System.Linq;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.Shared.TestData
{
    [Serializable]
    public class SaveData
    {
        private const int row_count = 6;

        private readonly int dataLength;

        private readonly Data[] datas;
        private readonly Guid[] guids;
        private readonly List<Data> list;
        private readonly Dictionary<Guid, Data> dictionary;

        private readonly Deck<Data> deck;
        private readonly Board<Data> board;
        private readonly DecrementalIndexes indexes;
        private readonly Map<Guid, Data> map;

        private readonly IPlayer[] players;
        private readonly PlayerStorage playerStorage;
        private readonly PlayerQueue playerQueue;

        public SaveData() : this(10) { }
        public SaveData(int dataLength)
        {
            this.dataLength = dataLength;

            datas = EntityCreator.CreateDatas(dataLength);
            guids = EntityCreator.CreateGuids(dataLength);

            list = new List<Data>(datas);

            dictionary = EntityCreator.CreateDictionary(dataLength);

            deck = new Deck<Data>(datas);

            board = EntityCreator.CreateBoard(row_count);

            indexes = EntityCreator.CreateDecrementalIndexes(dataLength);

            map = new Map<Guid, Data>(guids, datas);

            EntityCreator.CreatePlayerPack(out players, out playerStorage, out playerQueue);
        }


        public bool Compare(SaveData save)
        {
            if (Enumerable.SequenceEqual(datas, save.datas) is false) return false;
            if (Enumerable.SequenceEqual(guids, save.guids) is false) return false;
            if (Enumerable.SequenceEqual(list, save.list) is false) return false;
            if (Enumerable.SequenceEqual(dictionary, save.dictionary) is false) return false;

            if (Enumerable.SequenceEqual(deck, save.deck) is false) return false;
            if (Enumerable.SequenceEqual(board, save.board) is false) return false;
            if (Enumerable.SequenceEqual(indexes, save.indexes) is false) return false;
            if (Enumerable.SequenceEqual(map.Reverse, save.map.Reverse) is false) return false;
            if (Enumerable.SequenceEqual(map.Forward, save.map.Forward) is false) return false;

            if (Enumerable.SequenceEqual(players.Select(p => p.Name), save.players.Select(p => p.Name)) is false) return false;
            if (Enumerable.SequenceEqual(playerStorage.All.Select(p => p.Name), save.playerStorage.All.Select(p => p.Name)) is false) return false;
            if (Enumerable.SequenceEqual(playerStorage.Active.Select(p => p.Name), save.playerStorage.Active.Select(p => p.Name)) is false) return false;
            if (Enumerable.SequenceEqual(playerStorage.Removed.Select(p => p.Name), save.playerStorage.Removed.Select(p => p.Name)) is false) return false;

            if (playerQueue.Attacker.Name != save.playerQueue.Attacker.Name) return false;
            if (playerQueue.Defender.Name != save.playerQueue.Defender.Name) return false;
            if (playerQueue.Action != save.playerQueue.Action) return false;

            return true;
        }

    }
}
