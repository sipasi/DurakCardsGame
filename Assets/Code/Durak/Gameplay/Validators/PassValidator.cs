using Framework.Durak.Entities;

using UnityEngine;

namespace Framework.Durak.Validators
{
    public class PassValidator : MonoBehaviour
    {
        [SerializeField] private BoardEntity board;

        public bool Validate()
        {
            return board.Value.IsEmpty is false;
        }
    }
}