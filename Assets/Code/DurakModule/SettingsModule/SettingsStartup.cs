using ProjectCard.Shared.SettingsModule;

using UnityEngine;

namespace ProjectCard.DurakModule.SettingsModule
{
    public class SettingsStartup : MonoBehaviour
    {
        [SerializeField] private DurakSettingsSaverLoader saverLoader;

        [SerializeField] private GamePlayersTypeModifier playersTypeModifier;
        [SerializeField] private AnimationSpeedModifier animationSpeedModifier;

        private async void Awake()
        {
            await saverLoader.Load();

            playersTypeModifier.Initialize();
            animationSpeedModifier.Initialize();
        }
    }
}
