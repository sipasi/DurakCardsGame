using System;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;

namespace ProjectCard.Shared.WindowModule
{
    public class DialogWindow : MonoBehaviour, IDialogWindow<DialogResult>
    {
        [SerializeField] private GameObject window;
        [SerializeField] private DialogWindowEvents events;
        [SerializeField] private DialogWindowProperties propeties;

        private UnityAction okClickAction;
        private UnityAction cancelClickAction;

        private readonly Func<DialogWindow, bool> monitor = static (window) => window.result != null;

        private DialogResult? result;

        public IDialogWindowProperties Propeties => propeties;


        private void Awake()
        {
            okClickAction = () => result = DialogResult.Ok;
            cancelClickAction = () => result = DialogResult.Cancel;

            result = null;
            window.SetActive(false);
        }


        public async UniTask<DialogResult> Show()
        {
            Enable();

            await UniTask.WaitUntilValueChanged(this, monitor);

            Disable();

            DialogResult temp = result.Value;

            result = null;

            return temp;
        }
        private void Enable()
        {
            window.SetActive(true);

            events.OkSelected += okClickAction;
            events.CancelSelected += cancelClickAction;
        }
        private void Disable()
        {
            events.OkSelected -= okClickAction;
            events.CancelSelected -= cancelClickAction;

            window.SetActive(false);
        }
    }
}