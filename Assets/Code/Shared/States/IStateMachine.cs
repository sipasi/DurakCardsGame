namespace Framework.Shared.States
{
    public interface IStateMachine<TTrigger>
    {
        void Fire(TTrigger trigger);
    }
}