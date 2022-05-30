using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal sealed class DeckCardMovement : CardMovementByLink<IDeckReference>, IDeckCardMovement
    {
        public DeckCardMovement(IDataMovementService movement, IReadonlyLink<IDeckReference, Transform> link)
            : base(movement, CardLookSide.Back, link) { }
    }
}