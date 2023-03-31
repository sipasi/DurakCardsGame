#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.States;
using Framework.Shared.Collections;
using Framework.Shared.Saves;
using Framework.Shared.States;

namespace Framework.Durak.Saves
{
    public readonly struct SaveEntitiesMapper
    {
        private readonly IStateTriggerInfo<DurakGameState> triggerInfo;
        private readonly IReadOnlyList<Data> datas;
        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IDiscardPile discard;
        private readonly IPlayerStorage<IPlayer> storage;
        private readonly IPlayerQueue<IPlayer> queue;

        public SaveEntitiesMapper(ISaveEntities entities)
        {
            triggerInfo = entities.TriggerInfo;
            datas = entities.Datas;
            deck = entities.Deck;
            board = entities.Board;
            discard = entities.DiscardPile;
            storage = entities.Storage;
            queue = entities.Queue;
        }

        public SaveData Map() => new()
        {
            Game = "Durak",

            Date = DateTime.Now.Date,

            Datas = datas,
            Deck = deck,
            Board = board,
            DiscardPile = discard,

            AllPlayers = storage.All,
            ActivePlayers = storage.Active.Select(player => player.Id).ToArray(),
            RemovedPlayers = storage.Removed.Select(player => player.Id).ToArray(),

            Attaker = queue.Attacker.Id,
            Defender = queue.Defender.Id,

            GameState = triggerInfo.CurrentTrigger,
        };
    }
}