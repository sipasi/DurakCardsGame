
using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.Shared.CollectionModule;

using Unity.Mathematics;

namespace ProjectCard.DurakModule.GameModule.StaticModule
{
    public static class Dealer
    {
        public static IEnumerable<Data> DealCards(Deck<Data> deck, CardEntityDataStorage hand, int maxCardsInHand)
        {
            if (CanDeal(deck, hand, maxCardsInHand) is false)
            {
                yield break;
            }

            int cardsNeed = CardsNeed(hand, maxCardsInHand);

            for (int i = 0; i < cardsNeed; i++)
            {
                if (deck.TryPop(out Data data) is false)
                {
                    yield break;
                }

                hand.Add(data);

                yield return data;
            }
        }
        public static Data? DealOneCard(Deck<Data> deck, CardEntityDataStorage hand, int maxCardsInHand)
        {
            if (CanDeal(deck, hand, maxCardsInHand) is false)
            {
                return null;
            }

            deck.TryPop(out var data);

            hand.Add(data);

            return data;
        }

        public static bool CanDeal(Deck<Data> deck, CardEntityDataStorage hand, int maxCardsInHand)
        {
            if (deck.IsEmpty)
            {
                return false;
            }

            int cardsDelta = CardsNeed(hand, maxCardsInHand);

            if (cardsDelta == 0)
            {
                return false;
            }

            return true;
        }

        public static int CardsNeed(CardEntityDataStorage hand, int maxCardsInHand) => math.max(0, maxCardsInHand - hand.Count);
        public static int CardsNeed(int hand, int maxCardsInHand) => math.max(0, maxCardsInHand - hand);
    }
}