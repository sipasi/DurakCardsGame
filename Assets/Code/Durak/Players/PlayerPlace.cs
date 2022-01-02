
using UnityEngine;

namespace Framework.Durak.Players
{
    public class PlayerPlace : MonoBehaviour
    {
        [field: SerializeField] public PlayerPosition Position { get; set; }
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}