#nullable enable

using System.Collections.Generic;

using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Framework.Shared.Input
{
    public class TapListener : ITapService
    {
        private readonly Pointer pointer;

        private readonly PointerEventData data;
        private readonly List<RaycastResult> results;

        private readonly GraphicRaycaster raycaster;

        private readonly List<IInputHandler<RaycastResult>> listeners;

        public TapListener(UserInputActions user, Pointer pointer, EventSystem eventSystem, GraphicRaycaster raycaster)
        {
            this.pointer = pointer;

            this.data = new PointerEventData(eventSystem);
            this.results = new List<RaycastResult>(capacity: 1);

            this.raycaster = raycaster;

            this.listeners = new List<IInputHandler<RaycastResult>>();

            user.Interactions.Tap.performed += Performed;
        }

        public void Add(IInputHandler<RaycastResult> handler) => listeners.Add(handler);
        public void Remove(IInputHandler<RaycastResult> handler) => listeners.Remove(handler);

        private void Performed(InputAction.CallbackContext context)
        {
            if (listeners.Count == 0)
            {
                return;
            }

            results.Clear();

            data.position = pointer.position.ReadValue();

            raycaster.Raycast(data, results);

            for (int i = 0; i < results.Count; i++)
            {
                RaycastResult raycast = results[i];

                Notify(ref raycast);
            }
        }

        private void Notify(ref RaycastResult raycast)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                IInputHandler<RaycastResult> handler = listeners[i];

                handler.Handle(ref raycast);
            }
        }
    }
}