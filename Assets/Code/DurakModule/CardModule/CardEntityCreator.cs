using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ScriptableModule;

using UnityEngine;

namespace ProjectCard.DurakModule.CardModule
{
    public static class CardEntityCreator
    {
        public static ICard[] Create(CardEntity prefab, Transform parent, CardTheme theme, int count)
        {
            ICard[] cards = new ICard[count];

            for (int i = 0; i < count; i++)
            {
                var instantiated = Object.Instantiate(prefab.gameObject, parent, instantiateInWorldSpace: false) as GameObject;

                var entity = cards[i] = instantiated.GetComponent<ICard>();

                entity.View.Face = theme.Faces[i];
                entity.View.Back = theme.Back;
            }

            return cards;
        }
    }
}