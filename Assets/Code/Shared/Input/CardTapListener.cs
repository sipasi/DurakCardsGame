#nullable enable

using Framework.Shared.Cards.Entities;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.Shared.Input
{
    public class CardTapListener : ICardTapService, IInputHandler<RaycastResult>
    {
        public event Tapped<ICard>? Tapped;

        public CardTapListener(ITapService tapService)
        {
            tapService.Add(this);
        }

        void IInputHandler<RaycastResult>.Handle(ref RaycastResult data)
        {
            GameObject gameObject = data.gameObject;

            var proxy = gameObject.GetComponentInParent<CardProxy>();

            if (proxy == null)
            {
                return;
            }

            Tapped?.Invoke(proxy.Card);
        }
    }
}