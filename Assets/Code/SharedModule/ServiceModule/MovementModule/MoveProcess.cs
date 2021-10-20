using ProjectCard.Shared.ServiceModule.CollectionModule;
using ProjectCard.Shared.ServiceModule.TaskModule;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.MovementModule
{
    public class MoveProcess : IProcess, IReusable
    {
        private bool finished;

        private float speed;

        private Transform current;
        private Transform target;

        public bool Finished => finished;


        public void Execute(float delta)
        {
            Vector3 currentPosition = current.position;
            Vector3 targetPosition = target.position;

            current.position = Vector3.MoveTowards(currentPosition, targetPosition, speed);

            finished = currentPosition == targetPosition;
        }

        public void Set(Transform current, Transform target, float speed = 1)
        {
            this.finished = false;

            this.speed = speed;
            this.current = current;
            this.target = target;
        }

        void IReusable.Reuse()
        {
            finished = false;

            speed = default;
            current = null;
            target = null;
        }
    }
}