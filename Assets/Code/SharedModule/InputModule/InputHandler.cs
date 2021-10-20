using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace ProjectCard.Shared.InputModule
{
    [RequireComponent(typeof(ICard))]
    public sealed class InputHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private bool interactable = true;
        [SerializeField] private ScriptableAction<ICard> click;

        private ICard entity;

        public bool Interactable { get => interactable; set => interactable = value; }


        private void Awake()
        {
            entity = GetComponent<ICard>();
        }


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (interactable is false) return;

            Assert.IsNotNull(entity, "Card can't be null");
            Assert.IsNotNull(click, "Click event can't be null");

            click.Rise(entity);
        }
    }
}