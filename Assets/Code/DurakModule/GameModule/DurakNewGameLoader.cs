
using System;
using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.ScriptableModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class DurakNewGameLoader : MonoBehaviour
    {
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

        [Header("Players")]
        [SerializeField] private PlayerInfo[] playersInfo;

        [Header("Entities")]
        [SerializeField] private PlayerStorageEntity playerStorage;
        [SerializeField] private PlayerQueueEntity playerQueue;
        [SerializeField] private DeckEntity deckEntity;
        [SerializeField] private TrashEntity trashEntity;
        [SerializeField] private BoardEntity boardEntity;
        [SerializeField] private PlayerEntity[] playerEntities;

        public void Load()
        {
            var datas = DataCreator.Create(deckSize.Suits, deckSize.Ranks);
            var entities = CardEntityCreator.Create(cardPrefab, cardParent, cardTheme, datas.Length);

            pairsMap.Initialize(entities, datas);

            IDeck<Data> deck = new Deck<Data>(datas);
            IBoard<Data> board = new Board<Data>(rowItemsCount: 6);

            IPlayer[] players = new IPlayer[playersInfo.Length];

            for (int i = 0; i < playersInfo.Length; i++)
            {
                var player = players[i] = new Player()
                {
                    Id = Guid.NewGuid(),
                    Name = playersInfo[i].name,
                    Position = playersInfo[i].position,
                    LookSide = playersInfo[i].side,
                    Selector = playersInfo[i].selector,

                    Hand = new List<Data>(datas.Length),
                };

                playerEntities[i].Initialize(player);
            }

            playerStorage.Initialize(new PlayerStorage(players));
            playerQueue.Initialize(new PlayerQueue(playerStorage.Entity));

            deckEntity.Initialize(deck);
            boardEntity.Initialize(board);
            trashEntity.Initialize(new List<Data>(deck.Count));

            stateMachine.Initialize();

            stateMachine.Fire(DurakGameState.GameStart);
        }

        [Serializable]
        private struct PlayerInfo
        {
            public string name;
            public PlayerPosition position;
            public CardSelectorType selector;
            public CardLookSide side;
        }
    }
}