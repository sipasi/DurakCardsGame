using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using UnityEngine;

namespace Framework.Shared.Audios
{
    internal class AudioSystemConfigurator : ServiceConfigurator
    {
        [Header("SoundSystem")]
        [SerializeField] private AudioSource source;

        [Header("Card movement sounds")]
        [SerializeField] private AudioClip begin;
        [SerializeField] private AudioClip end;

        public override void Configure(ServiceBuilder builder)
        {
            var soundSystem = new SoundSystem(source);

            builder.singleton
                .Add<ISoundSystem>(soundSystem)
                .Add<ICardMovementSounds>(new CardMovementSounds(soundSystem, begin, end));
        }
    }
}
