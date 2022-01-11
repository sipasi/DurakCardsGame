
using Framework.Durak.Collections;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class CardModuleInstaller : MonoBehaviour, IEntityInstaller<(DeckEntity deck, DataList dataList, CardList cardList, CardMap map)>
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Installers")]
        [SerializeField] private DataListInstaller dataInstaller;
        [SerializeField] private CardListInstaller cardInstaller;
        [SerializeField] private DeckEntityInstaller deckInstaller;

        public void Install((DeckEntity deck, DataList dataList, CardList cardList, CardMap map) entities)
        {
            int total = size.Suits * size.Ranks;

            Assert.IsFalse(total == 0);

            dataInstaller.Install(entities.dataList);

            cardInstaller.Install(entities.cardList);

            deckInstaller.Install(entities.deck);

            Assert.IsNotNull(entities.dataList.Values);

            Assert.IsNotNull(entities.cardList.Values);

            Assert.IsNotNull(entities.deck.Value);
        }
    }
}