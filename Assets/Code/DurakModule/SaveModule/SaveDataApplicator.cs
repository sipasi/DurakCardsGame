
using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.EntityModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.SaveModule
{
    public class SaveDataApplicator : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private CardMovementManager movement;

        [Header("Entities")]
        [SerializeField] private EntityPlace<IDeck<Data>> deck;
        [SerializeField] private EntityPlace<List<Data>> trash;

        [SerializeField] private BoardEntity boardEntity;
        [SerializeField] private BoardPlaces boardPlaces;

        [SerializeField] private PlayerStorageEntity playerStorage;


        [Header("Collections")]
        [SerializeField] private PlayerPlaceList playerPlaceList;
        [SerializeField] private CardEntityDataMap entityDataMap;

        [Header("View")]
        [SerializeField] private DeckViewUpdater viewUpdater;

        public async UniTask Apply()
        {
            viewUpdater.UpdateCount();
            viewUpdater.UpdateSprites();

            await MoveToPlace(deck, CardLookSide.Back);

            await MoveToPlace(trash, CardLookSide.Face);

            await MoveCardsToBoard();

            await MoveCardsToPlayers();
        }

        private async UniTask MoveCardsToPlayers()
        {
            var active = playerStorage.Entity.Active;

            foreach (var player in active)
            {
                var hand = player.Hand;
                var place = playerPlaceList.Get(player.Position);
                var transform = place.Transform;

                await movement.MoveToPlace(hand, transform, player.LookSide);
            }
        }

        private async UniTask MoveCardsToBoard()
        {
            static async UniTask MoveToBoard(CardEntityDataMap map, IReadOnlyList<Data> cards, Func<ICard, int, UniTask> func)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    var data = cards[i];
                    var card = map.Get(data);

                    await func.Invoke(card, i);
                }
            }
            var board = boardEntity.Entity;

            var attacks = board.Attacks;
            var defends = board.Defends;

            await MoveToBoard(entityDataMap, attacks, boardPlaces.AddToAttacks);
            await MoveToBoard(entityDataMap, defends, boardPlaces.AddToDefends);
        }

        private UniTask MoveToPlace<T>(EntityPlace<T> entityPlace, CardLookSide lookSide)
            where T : class, IEnumerable<Data>
        {
            IEnumerable<Data> datas = entityPlace.Entity.Entity;

            return movement.MoveToPlace(datas, entityPlace.Place, lookSide);
        }

        [Serializable]
        private struct EntityPlace<T> where T : class, IEnumerable<Data>
        {
            [SerializeField] private GameplayEntity<T> entity;
            [SerializeField] private Transform place;

            public GameplayEntity<T> Entity { get => entity; set => entity = value; }
            public Transform Place { get => place; set => place = value; }
        }
    }
}