using Framework.Durak.Collections;
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
            IReadonlyLink<IDeckReference, Transform> deckLink = new Link<IDeckReference, Transform>(deck);
            IReadonlyLink<IDiscardPileReference, Transform> discardLink = new Link<IDiscardPileReference, Transform>(discard);

            builder.singleton
                .Add(deckLink)
                .Add(discardLink);
        }
    }
}
