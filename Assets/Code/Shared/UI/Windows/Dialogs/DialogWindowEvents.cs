
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Framework.Shared.UI.Windows.Dialogs
{
    public class DialogWindowEvents : MonoBehaviour
    {
        [SerializeField] private Button ok;
        [SerializeField] private Button cancel;

        public event UnityAction OkSelected
        {
            add => ok.onClick.AddListener(value);
            remove => ok.onClick.RemoveListener(value);
        }
        public event UnityAction CancelSelected
        {
            add => cancel.onClick.AddListener(value);
            remove => cancel.onClick.RemoveListener(value);
        }
    }
}