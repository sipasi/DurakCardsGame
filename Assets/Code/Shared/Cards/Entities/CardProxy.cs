using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public class CardProxy : MonoBehaviour
    {
        public ICard Card { get; internal set; }
    }
}