
using UnityEngine;

namespace ProjectCard.Shared.ScriptableModule
{
    [CreateAssetMenu(fileName = "TimeDelayVariables", menuName = "MyAsset/Shared/ScriptableModule/TimeDelayVariables")]
    public class TimeDelayVariables : ScriptableObject
    {
        [field: Header("Milliseconds")]
        [field: SerializeField, Range(1, 1000)] public int MoveDelay { get; private set; }
    }
}