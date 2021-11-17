
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.SaveModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.SaveModule;
using ProjectCard.Shared.ScriptableModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class DurakSavedGameLoader : MonoBehaviour
    {
        [Header("Save")]
        [SerializeField] private GuidSaveService saveService;

        [SerializeField] private SaveKey gameplayDataSaveKey;

        [SerializeField] private SaveLoader saveLoader;

        [Header("Card Property")]
        [SerializeField] private CardEntity cardPrefab;
        [SerializeField] private Transform cardParent;
        [SerializeField] private CardTheme cardTheme;

        [Header("Deck")]
        [SerializeField] private PlayingDeckSize deckSize;

        [Header("State Machine")]
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap pairsMap;

        [Header("Other")]
        [SerializeField] private SaveDataApplicator saveApplicator;


        public async UniTask Load()
        {
            var datas = DataCreator.Create(deckSize.Suits, deckSize.Ranks);
            var entities = CardEntityCreator.Create(cardPrefab, cardParent, cardTheme, datas.Length);

            pairsMap.Initialize(entities, datas);

            await saveLoader.LoadSave();

            await saveApplicator.Apply();

            GameplayData gameplayData = saveService.Restore<GameplayData>(gameplayDataSaveKey.Key);

            stateMachine.Initialize();

            stateMachine.Fire(gameplayData.GameState);
        }
    }
}
