using Cysharp.Threading.Tasks;

using ProjectCard.Durak.CollectionModule;
using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.Gameplay.Scriptables;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Durak.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Services.Movement;

using UnityEngine;

namespace ProjectCard.Durak.GameplayModule
{
    public class CardDealer : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap map;

        [Header("Players")]
        [SerializeField] private PlayerStorageEntity storage;
        [SerializeField] private PlayerPlaceList placeList;

        [Header("Shared")]
        [SerializeField] private DurakRules rules;

        [Header("Entities")]
        [SerializeField] private DeckEntity deck;

        [Header("View")]
        [SerializeField] private DeckViewUpdater deckView;

        public async UniTask DealCard()
        {
            foreach (var player in storage.Value.Active)
            {
                var entity = deck.Value;

                foreach (var data in Dealer.DealCards(entity, player.Hand, rules.MaxCardsInHand))
                {
                    ICard card = map.Get(data);

                    card.View.LookSide = player.LookSide;

                    PlayerPlace playerPlace = placeList.Get(player.Position);

                    Transform place = playerPlace.Transform;

                    deckView.UpdateCount();

                    await movement.MoveToPlace(card, place, player.LookSide);
                }
            }
        }
    }
}