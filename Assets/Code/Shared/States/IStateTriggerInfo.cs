namespace Framework.Shared.States
{
    public interface IStateTriggerInfo<TTrigger>
    {
        TTrigger CurrentTrigger { get; }
    }
}