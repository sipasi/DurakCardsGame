namespace ProjectCard.DurakModule.PlayerModule
{
    public interface IPlayerCardSelection
    {
        CardSelectorType Type { get; }

        ICardSelector Attack { get; }
        ICardSelector Defend { get; }
    }
}