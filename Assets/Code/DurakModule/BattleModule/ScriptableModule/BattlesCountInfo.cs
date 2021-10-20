
using UnityEngine;

namespace ProjectCard.DurakModule.BattleModule.ScriptableModule
{
    [CreateAssetMenu(fileName = "BattlesCountInfo", menuName = "MyAsset/Durak/BattleModule/BattlesCountInfo")]
    public class BattlesCountInfo : ScriptableObject
    {
        private int battlesCount = 0;

        public bool IsFirstBattle => battlesCount == 0;

        public void IncreaseBattlesCount() => battlesCount++;

        public void Clear()
        {
            battlesCount = 0;
        }
    }
}
