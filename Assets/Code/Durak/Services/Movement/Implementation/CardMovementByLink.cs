using Framework.Shared.Cards.Views;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal class CardMovementByLink<TLink> : CardMovement
    {
        private readonly IReadonlyLink<TLink, Transform> link;

        public CardMovementByLink(IDataMovementService movement, CardLookSide lookSide, IReadonlyLink<TLink, Transform> link)
            : base(movement, lookSide) => this.link = link;


        protected override Transform GetTarget() => link.Value;
    }
}