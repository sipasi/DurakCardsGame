using Framework.Durak.Collections;
using Framework.Durak.Game;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Structures.Links;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    public class DurakLinkConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        [SerializeField] private Transform deck;
        [SerializeField] private Transform discard;

        public void Configure(ServiceBuilder builder)
        {
            IReadonlyLink<IDeckReference, ICardOwner> deckLink = new Link<IDeckReference, ICardOwner>(new CardOwner(deck));
            IReadonlyLink<IDiscardPileReference, ICardOwner> discardLink = new Link<IDiscardPileReference, ICardOwner>(new CardOwner(discard));

            builder.singleton
                .Add(deckLink)
                .Add(discardLink);
        }
    }
}
