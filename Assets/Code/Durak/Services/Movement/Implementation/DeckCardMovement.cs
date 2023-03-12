using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Structures.Links;

namespace Framework.Durak.Services.Movements
{
    internal sealed class DeckCardMovement : CardMovementByLink<IDeckReference>, IDeckCardMovement
    {
        public DeckCardMovement(IDataMovementService movement, IReadonlyLink<IDeckReference, ICardOwner> link)
            : base(movement, CardLookSide.Back, link) { }
    }
}