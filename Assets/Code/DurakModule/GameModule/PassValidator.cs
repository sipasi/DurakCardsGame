using ProjectCard.DurakModule.GameModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ValidatorModule
{
    public class PassValidator : MonoBehaviour
    {
        [SerializeField] private SharedEntities shared;

        public bool Validate()
        {
            return shared.Board.IsEmpty is false;
        }
    }
}