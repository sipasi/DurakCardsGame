using Framework.Durak.Collections;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Structures.Links;

namespace Framework.Durak.Services.Movements
{
    internal sealed class DiscardPileCardMovement : CardMovementByLink<IDiscardPileReference>, IDiscardPileCardMovement
    {
        public DiscardPileCardMovement(IDataMovementService movement, IReadonlyLink<IDiscardPileReference, ICardOwner> link)
            : base(movement, CardLookSide.Back, link) { }
    }
}