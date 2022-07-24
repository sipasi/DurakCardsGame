using Framework.Shared.Cards.Entities;

using UnityEngine;

namespace Framework.Shared.Cards.Input
{
    [CreateAssetMenu(fileName = "CardInputInteractions", menuName = "MyAsset/Shared/Cards/CardInputInteractions")]
    internal sealed class CardInputInteractions : ScriptableObject, ICardInputInteractions
    {
        public event CardInteraction Selected;

        internal void OnSelected(ICard card) => Selected?.Invoke(card);
    }
}