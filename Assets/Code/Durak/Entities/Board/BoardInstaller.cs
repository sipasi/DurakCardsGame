using Framework.Durak.Datas;
using Framework.Shared.Collections;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class BoardInstaller : MonoBehaviour, IEntityInstaller<BoardEntity>
    {
        [SerializeField] private Places<Transform>.Pair[] pairs;

        public void Install(BoardEntity entity)
        {
            Assert.IsNotNull(pairs);

            var board = new Board<Data>(pairs.Length);
            var places = new Places<Transform>(pairs);

            entity.Initialize(board, places);
        }
    }
}