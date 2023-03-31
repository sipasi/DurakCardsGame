using Framework.Shared.Audios;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    internal class AudioSystemConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        [Header("SoundSystem")]
        [SerializeField] private AudioSource source;

        [Header("Card movement sounds")]
        [SerializeField] private AudioClip begin;
        [SerializeField] private AudioClip end;

        public void Configure(ServiceBuilder builder)
        {
            var soundSystem = new SoundSystem(source);

            builder.singleton
                .Add<ISoundSystem>(soundSystem)
                .Add<ICardMovementSounds>(new CardMovementSounds(soundSystem, begin, end));
        }
    }
}
