using ProjectCard.DurakModule.EntityModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ValidatorModule
{
    public class PassValidator : MonoBehaviour
    {
        [SerializeField] private BoardEntity board;

        public bool Validate()
        {
            return board.Entity.IsEmpty is false;
        }
    }
}