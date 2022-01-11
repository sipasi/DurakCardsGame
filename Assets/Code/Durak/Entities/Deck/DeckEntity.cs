using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Entities;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class DeckEntity : MonoBehaviour, IDeckEntity<Data>
    {
        private IReadOnlyList<ICard> cards;
        private IDeck<Data> deck;

        private Transform place;

        [SerializeField] private DurakCardMovementManager movement;

        public IReadonlyDeck<Data> Value => deck;

        public void Initialize(IDeck<Data> deck, IReadOnlyList<ICard> cards, Transform place)
            => (this.deck, this.cards, this.place) = (deck, cards, place);

        public bool TryPop(out Data data) => deck.TryPop(out data);

        public void Shuffle(int times) => deck.Shuffle(times);

        public async UniTask Reset()
        {
            deck.Clear();

            await movement.MoveToPlace(deck, place, CardLookSide.Back);
        }
    }
}