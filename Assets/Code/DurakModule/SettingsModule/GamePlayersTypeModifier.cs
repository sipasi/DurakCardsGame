
using System;

using ProjectCard.DurakModule.GameModule;

using TMPro;

using UnityEngine;

namespace ProjectCard.DurakModule.SettingsModule
{
    public class GamePlayersTypeModifier : MonoBehaviour
    {
        [SerializeField] private GamePlayersType playersType;
        [SerializeField] private TMP_Dropdown dropdown;

        public void Initialize()
        {
            int value = (int)playersType.PlayersType;

            dropdown.SetValueWithoutNotify(value);
        }

        private void OnEnable()
        {
            dropdown.onValueChanged.AddListener(OnSelected);
        }
        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(OnSelected);
        }

        private void OnSelected(int index)
        {
            PlayersType result = index switch
            {
                0 => PlayersType.HumanAi,
                1 => PlayersType.AiOnly,
                _ => throw new ArgumentException($"Index[{index}] don't support")
            };

            playersType.PlayersType = result;
        }
    }
}