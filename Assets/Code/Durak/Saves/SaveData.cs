using System;
using System.Collections.Generic;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.States;
using Framework.Shared.Collections;
using Framework.Shared.Saves;

namespace Framework.Durak.Saves
{
    [Serializable]
    public class SaveData : ISaveMetadata
    {
        public string Game { get; set; }
        public DateTime Date { get; set; }

        public IReadOnlyList<Data> Datas { get; set; }

        public IDeck<Data> Deck { get; set; }

        public IBoard<Data> Board { get; set; }

        public IDiscardPile DiscardPile { get; set; }

        public IReadOnlyList<IPlayer> AllPlayers { get; set; }
        public IReadOnlyList<Guid> ActivePlayers { get; set; }
        public IReadOnlyList<Guid> RemovedPlayers { get; set; }

        public Guid Attaker { get; set; }
        public Guid Defender { get; set; }

        public DurakGameState GameState { get; set; }
    }
}