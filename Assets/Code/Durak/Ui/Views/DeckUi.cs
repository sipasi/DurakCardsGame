
using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using System;

namespace Framework.Durak.Ui.Views
{

    internal class DeckUi : IDeckUi
    {
        private readonly IDeck<Data> deck;
        private readonly IDeckView view;

        private readonly IMap<ICard, Data> map;

        private readonly IStorage<int> storage;

        private static readonly Func<int, string> factory = (key) => key.ToString();

        public DeckUi(IDeck<Data> deck, IDeckView view, IMap<ICard, Data> map)
        {
            this.deck = deck;
            this.view = view;
            this.map = map;

            storage = new Storage<int>(catacity: deck.Count);
        }

        public void UpdateCount()
        {
            int count = deck.Count;

            string text = storage.RestoreOrCreate(key: count, factory);

            view.Count = text;
        }

        public void UpdateTrump()
        {
            Data trump = deck.Bottom;

            ICard card = map.Get(trump);

            view.Trump = card.View.Face;
        }
    }
}
