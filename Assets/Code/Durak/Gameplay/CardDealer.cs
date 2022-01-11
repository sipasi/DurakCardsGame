using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Cards.Entities;

using UnityEngine;

namespace Framework.Durak.Gameplay
{
    public class CardDealer : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerStorageEntity storage;

        [Header("Shared")]
        [SerializeField] private DurakRules rules;

        [Header("Entities")]
        [SerializeField] private DeckEntity deck;


        public async UniTask DealCard()
        {
            foreach (var player in storage.Value.Active)
            {
                foreach (var data in Dealer.DealCards(deck, player.Value.Hand, rules.MaxCardsInHand))
                {
                    await player.Add(data);
                }
            }
        }
    }
}