using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public class CardMovementByLink<TLink> : CardMovement
    {
        private readonly IReadonlyLink<TLink, ICardOwner> link;

        public CardMovementByLink(IDataMovementService movement, CardLookSide lookSide, IReadonlyLink<TLink, ICardOwner> link)
            : base(movement, lookSide) => this.link = link;


        protected override ICardOwner GetTarget() => link.Value;
    }
}