using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public interface ICardNavigation
    {
        Vector3 Position { get; set; }
        Vector3 Local { get; set; }

        void MoveTo(in Vector3 target);
        void SetParent(Transform parent);
    }

    public class TransformNavigation : ICardNavigation
    {
        private readonly Transform transform;

        public TransformNavigation(Transform transform) => this.transform = transform;

        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public Vector3 Local { get => transform.localPosition; set => transform.localPosition = value; }

        public void MoveTo(in Vector3 target)
        {
            transform.position = target;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
    }
}