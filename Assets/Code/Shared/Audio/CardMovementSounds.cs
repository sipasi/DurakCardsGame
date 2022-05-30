
using UnityEngine;

namespace Framework.Shared.Audios
{
    internal class CardMovementSounds : ICardMovementSounds
    {
        private readonly ISoundSystem sound;

        private readonly AudioClip begin;
        private readonly AudioClip end;

        public CardMovementSounds(ISoundSystem sound, AudioClip begin, AudioClip end)
        {
            this.sound = sound;
            this.begin = begin;
            this.end = end;
        }

        public void PlayBeginMovement() => sound.Play(begin);
        public void PlayEndMovement() => sound.Play(end);
    }
}
