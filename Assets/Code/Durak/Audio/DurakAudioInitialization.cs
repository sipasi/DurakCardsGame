using Framework.Shared.Audios;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Services.Movements;

using UnityEngine;

namespace Framework.Durak.Audios
{
    internal class DurakAudioInitialization : MonoBehaviour, IInitializable, IDestroyable
    {
        public void Initialize(IDiContainer container)
        {
            var movement = container.Get<ICardMovementService>();
            var sounds = container.Get<ICardMovementSounds>();

            movement.Begin += sounds.PlayBeginMovement;
            movement.End += sounds.PlayEndMovement;
        }

        void IDestroyable.Destroy(IDiContainer container)
        {
            var movement = container.Get<ICardMovementService>();
            var sounds = container.Get<ICardMovementSounds>();

            movement.Begin -= sounds.PlayBeginMovement;
            movement.End -= sounds.PlayEndMovement;
        }
    }
}