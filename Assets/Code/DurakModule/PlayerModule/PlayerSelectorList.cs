
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerSelectorList : MonoBehaviour
    {
        [SerializeField] private List<PlayerCardSelection> selectors;

        public IPlayerCardSelection Get(CardSelectorType type)
        {
            foreach (IPlayerCardSelection selector in selectors)
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