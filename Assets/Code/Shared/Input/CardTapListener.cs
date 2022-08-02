#nullable enable

using System.Collections.Generic;

using Framework.Shared.Cards.Entities;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.Shared.Input
{
    internal class CardTapListener : ICardTapService, IInputHandler<RaycastResult>
    {
        public event Tapped<ICard>? Tapped;

        public CardTapListener(ITapService tapService)
        {
            tapService.Add(this);
        }

        void IInputHandler<RaycastResult>.Handle(ref RaycastResult data)
        {
            GameObject gameObject = data.gameObject;

            ICard? card = gameObject.GetComponentInParent<ICard>();

            if (card is null || card.InputSensitive is false)
            {
                return;
            }

            Tapped?.Invoke(card);
        }
    }
}