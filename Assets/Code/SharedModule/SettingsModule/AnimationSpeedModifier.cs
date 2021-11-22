using ProjectCard.Shared.ScriptableModule;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace ProjectCard.Shared.SettingsModule
{
    public class AnimationSpeedModifier : MonoBehaviour
    {
        [SerializeField] private AnimationsSpeed animationsSpeed;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Slider slider;

        public void Initialize()
        {
            UpdateSpeedText();

            slider.value = animationsSpeed.CardMovement;
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
        }
        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void UpdateSpeedText()
        {
            text.text = $"Animation speed: {animationsSpeed.CardMovement}";
        }

        private void OnValueChanged(float value)
        {
            animationsSpeed.CardMovement = value;

            UpdateSpeedText();
        }
    }
}