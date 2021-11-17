
using UnityEngine;

namespace ProjectCard.Shared.GameModule
{
    [CreateAssetMenu(fileName = "GameLoadProperties", menuName = "MyAsset/Shared/GameModule/GameLoadProperties")]
    public class GameLoadProperties : ScriptableObject
    {
        [field: SerializeField] public GameLoadType LoadType { get; set; }
    }
}
