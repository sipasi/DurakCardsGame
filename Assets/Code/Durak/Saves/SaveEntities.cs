#nullable enable

using System.Collections.Generic;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.States;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.Saves
{
    public interface ISaveEntities
    {
        IBoard<Data> Board { get; }
        IReadOnlyList<Data> Datas { get; }
        IDeck<Data> Deck { get; }
        IDiscardPile DiscardPile { get; }
        IPlayerQueue<IPlayer> Queue { get; }
        IPlayerStorage<IPlayer> Storage { get; }
        IStateTriggerInfo<DurakGameState> TriggerInfo { get; }
    }

    public sealed class SaveEntities : ISaveEntities
    {
        public IStateTriggerInfo<DurakGameState> TriggerInfo { get; }
        public IReadOnlyList<Data> Datas { get; }
        public IDeck<Data> Deck { get; }
        public IBoard<Data> Board { get; }
        public IDiscardPile DiscardPile { get; }
        public IPlayerStorage<IPlayer> Storage { get; }
        public IPlayerQueue<IPlayer> Queue { get; }

        public SaveEntities(IStateTriggerInfo<DurakGameState> triggerInfo, IReadOnlyList<Data> datas, IDeck<Data> deck, IBoard<Data> board, IDiscardPile discard, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage)
        {
            this.TriggerInfo = triggerInfo;
            this.Datas = datas;
            this.Deck = deck;
            this.Board = board;
            this.DiscardPile = discard;
            this.Storage = storage;
            this.Queue = queue;
        }
    }
}