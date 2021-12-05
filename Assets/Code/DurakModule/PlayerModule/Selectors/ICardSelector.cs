namespace ProjectCard.DurakModule.PlayerModule
{
    public interface ICardSelector
    {
        void Begin(IPlayer player);
        void End(IPlayer player);
    }
}