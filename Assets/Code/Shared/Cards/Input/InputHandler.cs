using Framework.Shared.Cards.Entities;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Framework.Shared.Cards.Input
{
    [RequireComponent(typeof(ICard))]
    public sealed class InputHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CardInputInteractions interactions;

        private ICard entity;

        private void Awake()
        {
            entity = GetComponent<ICard>();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            Assert.IsNotNull(entity, "Entity can't be null");
            Assert.IsNotNull(interactions, "Input interactions can't be null");

            interactions.OnSelected(entity);
        }
    }
}