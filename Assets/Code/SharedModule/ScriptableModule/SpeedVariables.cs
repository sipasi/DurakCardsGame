
using UnityEngine;

namespace ProjectCard.Shared.ScriptableModule
{
    [CreateAssetMenu(fileName = "SpeedVariables", menuName = "MyAsset/Shared/ScriptableModule/SpeedVariables")]
    public class SpeedVariables : ScriptableObject
    {
        [field: SerializeField, Range(.1f, 5f)] public float CardMovement { get; set; }
    }
}