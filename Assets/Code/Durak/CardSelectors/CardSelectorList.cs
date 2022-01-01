
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.Durak.PlayerModule
{
    public class CardSelectorList : MonoBehaviour
    {
        [SerializeField] private List<PlayerCardSelection> selectors;

        public IPlayerCardSelection Get(PlayerType type)
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