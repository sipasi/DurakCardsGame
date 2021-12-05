using System;

using ProjectCard.Shared.ScriptableModule;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace ProjectCard.Shared.SettingsModule
{
    public class AnimationSpeedModifier : MonoBehaviour
    {
        [SerializeField] private SpeedVariables animationsSpeed;
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
            text.text = $"Animation speed: {animationsSpeed.CardMovement:0.00}";
        }

        private void OnValueChanged(float value)
        {
            float rounded = (float)Math.Round(value, digits: 2);

            slider.SetValueWithoutNotify(rounded);

            animationsSpeed.CardMovement = rounded;

            UpdateSpeedText();
        }
    }
}