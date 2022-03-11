namespace Framework.Durak.Players.Selectors
{
    public interface ISelectorsGroup
    {
        ICardSelector Attacking { get; }
        ICardSelector Defending { get; }
    }
}