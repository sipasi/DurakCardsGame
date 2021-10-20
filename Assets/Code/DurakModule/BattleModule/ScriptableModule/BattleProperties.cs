
using UnityEngine;

namespace ProjectCard.DurakModule.BattleModule.ScriptableModule
{
    [CreateAssetMenu(fileName = "BattleProperties", menuName = "MyAsset/Durak/BattleModule/BattleProperties")]
    public class BattleProperties : ScriptableObject
    {
        [field: SerializeField] public bool IsAttackerChangable { get; set; }
    }
}
