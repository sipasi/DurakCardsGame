using Framework.Durak.Collections;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Structures
{
    public class DurakLinkConfigurator : ServiceConfigurator
    {
        [SerializeField] private Transform deck;
        [SerializeField] private Transform discard;

        public override void Configure(ServiceBuilder builder)
        {
            IReadonlyLink<IDeckReference, ICardOwner> deckLink = new Link<IDeckReference, ICardOwner>(new CardOwner(deck));
            IReadonlyLink<IDiscardPileReference, ICardOwner> discardLink = new Link<IDiscardPileReference, ICardOwner>(new CardOwner(discard));

            builder.singleton
                .Add(deckLink)
                .Add(discardLink);
        }
    }
}
