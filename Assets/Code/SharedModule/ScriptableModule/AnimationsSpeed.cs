
using UnityEngine;

namespace ProjectCard.Shared.ScriptableModule
{
    [CreateAssetMenu(fileName = "AnimationsSpeed", menuName = "MyAsset/Shared/ScriptableModule/AnimationsSpeed")]
    public class AnimationsSpeed : ScriptableObject
    {
        [field: SerializeField, Range(.1f, 5f)] public float CardMovement { get; set; }
    }
}