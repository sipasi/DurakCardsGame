
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerSelectorList : MonoBehaviour
    {
        [SerializeField] private List<CardSelector> selectors;

        public ICardSelector Get(CardSelectorType type)
        {
            foreach (ICardSelector selector in selectors)
            {
                if (selector.Type == type)
                {
                    return selector;
                }
            }

            throw new System.ArgumentException();
        }
    }
}