using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ScriptableModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ServiceModule.MovementModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameplayModule
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
            foreach (var player in storage.Entity.Active)
            {
                var entity = deck.Entity;

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