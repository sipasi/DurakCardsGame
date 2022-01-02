
using System.Collections.Generic;

using Framework.Durak.Players;

using UnityEngine;

namespace Framework.Durak.Cards.Selectors
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