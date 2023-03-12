using Framework.Shared.Cards.Entities;
using Framework.Shared.Services.Pools;

using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public class MoveProcess : IProcess, IReusable
    {
        private bool finished;

        private float speed;

        private ICardNavigation current;
        private ICardNavigation target;

        public bool Finished => finished;

        public void Execute(float delta)
        {
            Vector3 currentPosition = current.Position;
            Vector3 targetPosition = target.Position;

            current.Position = Vector3.MoveTowards(currentPosition, targetPosition, speed * delta);

            finished = currentPosition == targetPosition;
        }

        public void Set(ICardNavigation current, ICardNavigation target, float speed = 1)
        {
            finished = false;

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