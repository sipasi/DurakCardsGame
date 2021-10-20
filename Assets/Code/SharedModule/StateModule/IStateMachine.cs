namespace ProjectCard.Shared.StateModule
{
    public interface IStateMachine<TTrigger>
    {
        void Fire(TTrigger trigger);
    }
}