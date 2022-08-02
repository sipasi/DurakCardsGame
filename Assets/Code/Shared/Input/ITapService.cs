#nullable enable

using UnityEngine.EventSystems;

namespace Framework.Shared.Input
{
    public interface ITapService
    {
        void Add(IInputHandler<RaycastResult> handler);
        void Remove(IInputHandler<RaycastResult> handler);
    }
}