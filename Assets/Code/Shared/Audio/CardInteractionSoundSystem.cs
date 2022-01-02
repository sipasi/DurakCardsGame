using System;

using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Shared.Audios
{
    public class CardInteractionSoundSystem : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private AudioSource source;

        [Header("Pairs")]
        [SerializeField] private AudioEventPair MovementBegin;
        [SerializeField] private AudioEventPair MovementEnd;


        private void OnEnable()
        {
            MovementBegin.Event.Action += OnMovementBegin;
            MovementEnd.Event.Action += OnMovementEnd;
        }
        private void OnDisable()
        {
            MovementBegin.Event.Action -= OnMovementBegin;
            MovementEnd.Event.Action -= OnMovementEnd;
        }


        private void OnMovementBegin() => PlaySound(MovementBegin);
        private void OnMovementEnd() => PlaySound(MovementEnd);

        private void PlaySound(AudioEventPair pair)
        {
            source.PlayOneShot(pair.Clip);
        }


        [Serializable]
        private struct AudioEventPair
        {
            [SerializeField] private AudioClip audio;
            [SerializeField] private ScriptableAction @event;

            public AudioClip Clip => audio;
            public ScriptableAction Event => @event;
        }
    }
}
