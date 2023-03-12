using Framework.Shared.Cards.Views;

namespace Framework.Shared.Cards.Entities
{
    public sealed class TemporaryCard : Card
    {
        public TemporaryCard(ICardView view, ICardNavigation navigation)
            : base(view, navigation) { }
    }
}