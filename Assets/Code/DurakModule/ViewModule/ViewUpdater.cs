
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ViewModule
{
    public class ViewUpdater : MonoBehaviour
    {
        [Header("Shared")]
        [SerializeField] private SharedEntities shared;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap map;

        [Header("Views")]
        [SerializeField] private DeckView deckView;

        public void UpdateDeck()
        {
            ICard trump = map.Get(shared.Deck.Bottom);
            Deck<Data> deck = shared.Deck;

            deckView.Trump = trump.View.Face;
            deckView.Back = trump.View.Back;
            deckView.Count = deck.Count.ToString();
        }
    }
}