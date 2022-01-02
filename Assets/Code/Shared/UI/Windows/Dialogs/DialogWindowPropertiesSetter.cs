
using UnityEngine;

namespace Framework.Shared.UI.Windows.Dialogs
{
    public class DialogWindowPropertiesSetter : MonoBehaviour
    {
        [SerializeField] private DialogWindowProperties properties;

        [Header("Default Values")]
        [SerializeField] private string title;
        [SerializeField] private string message;
        [SerializeField] private string ok;
        [SerializeField] private string cancel;

        private void OnValidate()
        {
            if (properties == null)
            {
                return;
            }

            properties.Title = title;
            properties.Message = message;
            properties.OkText = ok;
            properties.CancelText = cancel;
        }
    }
}
