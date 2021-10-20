using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.GameModule.StaticModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ScriptableModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.ServiceModule.MovementModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class CardDealer : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap map;

        [Header("Players")]
        [SerializeField] private PlayerStorage storage;

        [Header("Shared")]
        [SerializeField] private DurakRules rules;
        [SerializeField] private SharedEntities shared;

        [Header("Views")]
        [SerializeField] private ViewUpdater viewUpdater; // TODO: make event


        public async UniTask DealCard()
        {
            Deck<Data> deck = shared.Deck;

            foreach (var player in storage.Active)
            {
                foreach (var data in Dealer.DealCards(deck, player.Hand, rules.MaxCardsInHand))
                {
                    ICard card = map.Get(data);

                    card.View.LookSide = player.LookSide;

                    viewUpdater.UpdateDeck();

                    await movement.MoveToPlace(card, player.Transform, player.LookSide);
                }
            }
        }
    }
}