
using System.Collections.Generic;

using Framework.Durak.Cards;
using Framework.Shared.Collections;

using Unity.Mathematics;

namespace Framework.Durak.Gameplay
{
    public static class Dealer
    {
        public static IEnumerable<Data> DealCards(IDeck<Data> deck, List<Data> hand, int maxCardsInHand)
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
        public static Data? DealOneCard(IDeck<Data> deck, List<Data> hand, int maxCardsInHand)
        {
            if (CanDeal(deck, hand, maxCardsInHand) is false)
            {
                return null;
            }

            deck.TryPop(out var data);

            hand.Add(data);

            return data;
        }

        public static bool CanDeal(IReadonlyDeck<Data> deck, List<Data> hand, int maxCardsInHand)
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

        public static int CardsNeed(List<Data> hand, int maxCardsInHand) => math.max(0, maxCardsInHand - hand.Count);
        public static int CardsNeed(int hand, int maxCardsInHand) => math.max(0, maxCardsInHand - hand);
    }
}