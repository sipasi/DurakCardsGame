
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ScriptableModule;

using UnityEngine;
using UnityEngine.Events;

namespace ProjectCard.DurakModule.GameModule
{
    public class Startup : MonoBehaviour
    {
        [Header("Card Property")]
        [SerializeField] private CardEntity cardPrefab;
        [SerializeField] private Transform cardParent;
        [SerializeField] private CardTheme cardTheme;

        [Header("Deck")]
        [SerializeField] private PlayingDeckSize deckSize;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap pairsMap;

        [Header("Players")]
        [SerializeField] private PlayerInfo[] players;
        [SerializeField] private PlayerStorage playerStorage;
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;

        [Header("Events")]
        [SerializeField] private UnityEvent StartupCompleted;


        private void Awake()
        {
            var datas = DataCreator.Create(deckSize.Suits, deckSize.Ranks);
            var entities = CardEntityCreator.Create(cardPrefab, cardParent, cardTheme, datas.Length);

            pairsMap.Initialize(entities, datas);

            playerStorage.Initialize(players);

            shared.Initialize(datas, boardRowItemsCount: 6);

            StartupCompleted.Invoke();
        }
    }
}