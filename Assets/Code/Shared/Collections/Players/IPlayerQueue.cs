namespace Framework.Shared.Collections
{
    public interface IPlayerQueue<T> : IReadonlyPlayerQueue<T>
    {
        public void SetAttackerQueue();
        public void SetDefenderQueue();
        public void SetAttackerQueue(T attacker, T defender);
        public void SetDefenderQueue(T attacker, T defender);
    }
}