#nullable enable

using Framework.Shared.Cards.Entities;

namespace Framework.Shared.Input
{
    public delegate void Tapped<T>(T item);

    public interface ICardTapService
    {
        event Tapped<ICard> Tapped;
    }
}