using ProjectCard.DurakModule.EntityModule;

using UnityEngine;


namespace ProjectCard.DurakModule.HandlerModule
{
    public class PassSelectionHandler : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Shared")]
        [SerializeField] private BoardEntity board;

        public bool Handle()
        {
            if (board.Value.IsEmpty)
            {
                return false;
            }

            return true;
        }
    }
}