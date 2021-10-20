
using UnityEngine;

namespace ProjectCard.DurakModule.BattleModule.ScriptableModule
{
    [CreateAssetMenu(fileName = "BattleResultInfo", menuName = "MyAsset/Durak/BattleModule/BattleResultInfo")]
    public class BattleResultInfo : ScriptableObject
    {
        private bool winnerDefined;

        private bool isAttakerWinner;

        public bool IsWinnerDefined => winnerDefined;

        public bool IsAttackerWinner => winnerDefined && isAttakerWinner is true;
        public bool IsDefenderWinner => winnerDefined && isAttakerWinner is false;

        public void SetAttackerAsBattleWinner()
        {
            winnerDefined = true;
            isAttakerWinner = true;
        }
        public void SetDefenderAsBattleWinner()
        {
            winnerDefined = true;
            isAttakerWinner = false;
        }

        public void Clear()
        {
            winnerDefined = false;
            isAttakerWinner = false;
        }
    }
}
