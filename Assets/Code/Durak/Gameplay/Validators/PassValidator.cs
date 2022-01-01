using ProjectCard.Durak.EntityModule;

using UnityEngine;

namespace ProjectCard.Durak.ValidatorModule
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