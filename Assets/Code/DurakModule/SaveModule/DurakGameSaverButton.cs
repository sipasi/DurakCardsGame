
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCard.DurakModule.SaveModule
{
    public class DurakGameSaverButton : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private DurakGameSaver durakGameSaver;

        private void Awake()
        {
            saveButton.onClick.AddListener(async () => await durakGameSaver.SaveGame());
        }
    }
}