namespace Framework.Durak.Rules
{
    public interface IPlayingDeckSize
    {
        int Suits { get; }
        int Ranks { get; }

        int Total { get; }
    }
}
