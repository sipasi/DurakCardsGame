
using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Durak.States;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class DurakNewGameLoader : MonoBehaviour
    {
        [Header("State Machine")]
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Collections")]
        [SerializeField] private DataList dataList;
        [SerializeField] private CardList cardList;
        [SerializeField] private CardMap map;

        [Header("Installer")]
        [SerializeField] private BoardInstaller boardInstaller;
        [SerializeField] private DiscardPileEntityInstaller discardPileEntityInstaller;
        [SerializeField] private CardModuleInstaller cardModuleInstaller;
        [SerializeField] private PlayerModuleInstaller playerModuleInstaller;

        [Header("Entities")]
        [SerializeField] private DeckEntity deckEntity;
        [SerializeField] private BoardEntity boardEntity;
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;
        [SerializeField] private DiscardPileEntity discardPileEntity;
        [SerializeField] private PlayerEntity[] playerEntities;


        public void Load()
        {
            cardModuleInstaller.Install((deckEntity, dataList, cardList, map));

            playerModuleInstaller.Install((playerEntities, playerStorage, playerQueue));

            boardInstaller.Install(boardEntity);

            discardPileEntityInstaller.Install(discardPileEntity);

            stateMachine.Initialize();

            stateMachine.Fire(DurakGameState.GameStart);
        }
    }
}