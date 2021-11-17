namespace ProjectCard.DurakModule.PlayerModule
{
    public interface ICardSelector
    {
        CardSelectorType Type { get; }

        void Begin();
        void End();
    }
}