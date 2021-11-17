
using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerPlace : MonoBehaviour
    {
        [field: SerializeField] public PlayerPosition Position { get; set; }
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}