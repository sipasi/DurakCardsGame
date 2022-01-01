namespace ProjectCard.Durak.PlayerModule
{
    public interface ICardSelector
    {
        void Begin(IPlayer player);
        void End(IPlayer player);
    }
}