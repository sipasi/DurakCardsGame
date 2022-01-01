
using TMPro;

using UnityEngine;

namespace ProjectCard.Shared.WindowModule
{
    public class DialogWindowProperties : MonoBehaviour, IDialogWindowProperties
    {
        [Header("Ui")]
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private TextMeshProUGUI ok;
        [SerializeField] private TextMeshProUGUI cancel;

        public string Title { get => title.text; set => title.text = value; }
        public string Message { get => message.text; set => message.text = value; }
        public string OkText { get => ok.text; set => ok.text = value; }
        public string CancelText { get => cancel.text; set => cancel.text = value; }
    }
}