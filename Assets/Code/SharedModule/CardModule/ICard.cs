

using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Shared.CardModule
{
    public interface ICard
    {
        CardView View { get; }
        Transform Transform { get; }
    }
}
