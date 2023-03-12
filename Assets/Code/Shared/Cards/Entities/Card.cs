#nullable enable

using Framework.Shared.Cards.Views;

namespace Framework.Shared.Cards.Entities
{
    public interface ICard
    {
        ICardView View { get; }
        ICardNavigation Navigation { get; }

        ICardOwner? Owner { get; set; }
    }

    public class Card : ICard
    {
        public ICardView View { get; }
        public ICardNavigation Navigation { get; }

        public ICardOwner? Owner { get; set; }

        public Card(ICardView view, ICardNavigation navigation)
        {
            View = view;
            Navigation = navigation;
        }
    }
}