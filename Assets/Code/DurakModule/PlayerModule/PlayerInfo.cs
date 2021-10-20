
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] new private string name;
        [SerializeField] new private Transform transform;
        [SerializeField] private CardEntityDataStorage hand;
        [SerializeField] private CardSelector selector;
        [SerializeField] private CardLookSide lookSide;

        public string Name => name;
        public Transform Transform => transform;
        public CardEntityDataStorage Hand => hand;
        public CardSelector Selector => selector;
        public CardLookSide LookSide => lookSide;
    }
}