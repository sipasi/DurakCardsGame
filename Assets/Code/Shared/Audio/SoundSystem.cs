
using System.Threading.Tasks;

using UnityEngine;

namespace Framework.Shared.Audios
{
    internal class SoundSystem : ISoundSystem
    {
        private readonly AudioSource source;

        public SoundSystem(AudioSource source)
        {
            this.source = source;
        }

        public void Play(AudioClip clip)
        {
            source.PlayOneShot(clip);
        }
    }
}
