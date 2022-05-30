using Framework.Shared.Audios;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Services.Movements;

namespace Framework.Durak.Audios
{
    internal class DurakAudioInitialization : ServiceInitialization, IDestroyable
    {
        public override void Initialize(IDiContainer container)
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