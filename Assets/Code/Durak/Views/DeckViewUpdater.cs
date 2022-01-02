using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.Views
{
    public class DeckViewUpdater : MonoBehaviour
    {
        [SerializeField] private DeckEntity entity;
        [SerializeField] private DeckView view;
        [SerializeField] private CardEntityDataMap map;

        public void UpdateSprites()
        {
            var deck = entity.Value;

            var trumpView = map.Get(deck.Bottom).View;

            view.Trump = trumpView.Face;
        }

        public void UpdateCount()
        {
            var deck = entity.Value;

            view.Count = deck.Count.ToString();
        }
    }
}