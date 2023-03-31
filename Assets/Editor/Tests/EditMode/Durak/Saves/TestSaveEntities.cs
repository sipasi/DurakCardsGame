using System.Collections.Generic;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.States;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.Saves
{
    public class TestSaveEntities : ISaveEntities
    {
        public IBoard<Data> Board { get; init; }
        public IReadOnlyList<Data> Datas { get; init; }
        public IDeck<Data> Deck { get; init; }
        public IDiscardPile DiscardPile { get; init; }
        public IPlayerQueue<IPlayer> Queue { get; init; }
        public IPlayerStorage<IPlayer> Storage { get; init; }
        public IStateTriggerInfo<DurakGameState> TriggerInfo { get; init; }
    }
}
