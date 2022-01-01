namespace ProjectCard.Durak.PlayerModule
{
    public interface IPlayerCardSelection
    {
        PlayerType Type { get; }

        ICardSelector Attack { get; }
        ICardSelector Defend { get; }
    }
}