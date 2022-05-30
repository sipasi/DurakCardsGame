using Framework.Shared.Cards.Entities;
using Framework.Shared.Signals;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Framework.Shared.Cards.Input
{
    internal class CardSelectedSignal : MonoBehaviour, IItemSelectedSignal<ICard>
    {
        public void Send(ICard card)
        {
            
        }
    }

    [RequireComponent(typeof(ICard))]
    public sealed class InputHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private bool interactable = true;
        [SerializeField] private CardSelectedSignal signal;

        private ICard entity;

        public bool Interactable { get => interactable; set => interactable = value; }


        private void Awake()
        {
            entity = GetComponent<ICard>();
        }


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (interactable is false) return;

            Assert.IsNotNull(entity, "Entity can't be null");
            Assert.IsNotNull(signal, "Selected signal can't be null");

            signal.Send(entity);
        }
    }
}