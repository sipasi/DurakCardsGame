using System.Diagnostics;

using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public interface ICardOwner
    {
        void Take(ICard card);
    }

    [DebuggerDisplay("{transform}")]
    public class CardOwner : ICardOwner
    {
        private readonly Transform transform;

        public CardOwner(Transform transform)
        {
            this.transform = transform;
        }

        public void Take(ICard card)
        {
            card.Owner = this;

            card.Navigation.SetParent(transform);

            card.Navigation.Local = Vector3.zero;
        }
    }
}