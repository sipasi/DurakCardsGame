using UnityEngine;

namespace Framework.Shared.Core
{
    public class FrameRateLimit : MonoBehaviour
    {
        [SerializeField] private Preset preset;

        void Awake()
        {
            Application.targetFrameRate = (int)preset;
        }

        private void OnValidate()
        {
            Application.targetFrameRate = (int)preset;
        }

        private enum Preset
        {
            None,
            Set30 = 30,
            Set60 = 60,
            Set120 = 120,
            Set240 = 240,
        }
    }
}
