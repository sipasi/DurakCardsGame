
using Framework.Durak.Collections;
using Framework.Shared.Cards.Views;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal sealed class DiscardPileCardMovement : CardMovementByLink<IDiscardPileReference>, IDiscardPileCardMovement
    {
        public DiscardPileCardMovement(IDataMovementService movement, IReadonlyLink<IDiscardPileReference, Transform> link)
            : base(movement, CardLookSide.Back, link) { }
    }
}