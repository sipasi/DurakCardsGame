using ProjectCard.Shared.StateModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public abstract class DurakState : MonoBehaviour, IState
    {
        [Space(height: 15), SerializeField] protected DurakGameStateMachine machine;

        public virtual void Enter()
        {
            Debug.Log($"{nameof(Enter)}: {GetType().Name}", this);
        }
        public virtual void Exit()
        {
            // Debug.Log($"{nameof(Exit)}: {GetType().Name}", this);
        }
    }
}