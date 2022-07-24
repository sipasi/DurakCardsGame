using Framework.Shared.Cards.Entities;

namespace Framework.Shared.Cards.Input
{
    public delegate void CardInteraction(ICard card);

    public interface ICardInputInteractions
    {
        event CardInteraction Selected;
    }
}