namespace ProjectCard.DurakModule.PlayerModule
{
    public interface ICardSelector
    {
        CardSelectorType Type { get; }

        void Begin(IPlayer player);
        void End(IPlayer player);
    }
}