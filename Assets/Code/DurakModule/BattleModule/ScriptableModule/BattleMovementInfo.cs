
using UnityEngine;

namespace ProjectCard.DurakModule.BattleModule.ScriptableModule
{
    [CreateAssetMenu(fileName = "BattleMovementInfo", menuName = "MyAsset/Durak/BattleModule/BattleMovementInfo")]
    public class BattleMovementInfo : ScriptableObject
    {
        private int movementInOneBattle = 0;

        public bool IsFirstMovement => movementInOneBattle == 0;

        public void IncreaseMovementCount() => movementInOneBattle++;

        public void Clear()
        {
            movementInOneBattle = 0;
        }
    }
}
