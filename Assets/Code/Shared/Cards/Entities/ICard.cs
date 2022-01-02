using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public interface ICard
    {
        CardView View { get; }
        Transform Transform { get; }
    }
}
