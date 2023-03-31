using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Collections;

namespace Framework.Shared.Tests
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
        private readonly PlayerStorage<IPlayer> playerStorage;
        private readonly PlayerQueue<IPlayer> playerQueue;

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
            if (datas.SequenceEqual(save.datas) is false)
                return false;
            if (guids.SequenceEqual(save.guids) is false)
                return false;
            if (list.SequenceEqual(save.list) is false)
                return false;
            if (dictionary.SequenceEqual(save.dictionary) is false)
                return false;

            if (deck.SequenceEqual(save.deck) is false)
                return false;
            if (board.SequenceEqual(save.board) is false)
                return false;
            if (indexes.SequenceEqual(save.indexes) is false)
                return false;
            if (map.Reverse.SequenceEqual(save.map.Reverse) is false)
                return false;
            if (map.Forward.SequenceEqual(save.map.Forward) is false)
                return false;

            if (players.Select(p => p.Name).SequenceEqual(save.players.Select(p => p.Name)) is false)
                return false;
            if (playerStorage.All.Select(p => p.Name).SequenceEqual(save.playerStorage.All.Select(p => p.Name)) is false)
                return false;
            if (playerStorage.Active.Select(p => p.Name).SequenceEqual(save.playerStorage.Active.Select(p => p.Name)) is false)
                return false;
            if (playerStorage.Removed.Select(p => p.Name).SequenceEqual(save.playerStorage.Removed.Select(p => p.Name)) is false)
                return false;

            if (playerQueue.Attacker.Name != save.playerQueue.Attacker.Name)
                return false;
            if (playerQueue.Defender.Name != save.playerQueue.Defender.Name)
                return false;

            return true;
        }

    }
}
