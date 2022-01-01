
using System;
using System.Collections.Generic;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CollectionModule;
using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Durak.StateModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Collections;
using ProjectCard.Shared.ScriptableModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Durak.GameModule
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
        [SerializeField] private DiscardPileEntity discardPileEntity;
        [SerializeField] private BoardEntity boardEntity;
        [SerializeField] private PlayerEntity[] playerEntities;

        [Header("Game")]
        [SerializeField] private PlayerType playerType;

        public void Load()
        {
            var datas = DataCreator.Create(deckSize.Suits, deckSize.Ranks);
            var entities = CardEntityCreator.Create(cardPrefab, cardParent, cardTheme, datas.Length);

            pairsMap.Initialize(entities, datas);

            IDeck<Data> deck = new Deck<Data>(datas);
            IBoard<Data> board = new Board<Data>(rowItemsCount: 6);

            Player[] players = new Player[playersInfo.Length];

            for (int i = 0; i < playersInfo.Length; i++)
            {
                var player = players[i] = new Player()
                {
                    Id = Guid.NewGuid(),
                    Name = playersInfo[i].name,
                    Position = playersInfo[i].position,
                    LookSide = playersInfo[i].side,
                    Type = playersInfo[i].type,

                    Hand = new List<Data>(datas.Length),
                };

                playerEntities[i].Initialize(player);
            }

            if (playerType == PlayerType.Ai)
            {
                foreach (var player in players)
                {
                    player.Type = PlayerType.Ai;
                }
            }

            playerStorage.Initialize(new PlayerStorage(players));
            playerQueue.Initialize(new PlayerQueue(playerStorage.Value));

            deckEntity.Initialize(deck);
            boardEntity.Initialize(board);
            discardPileEntity.Initialize(new List<Data>(deck.Count));

            stateMachine.Initialize();

            stateMachine.Fire(DurakGameState.GameStart);
        }

        [Serializable]
        private struct PlayerInfo
        {
            public string name;
            public PlayerPosition position;
            public PlayerType type;
            public CardLookSide side;
        }
    }
}