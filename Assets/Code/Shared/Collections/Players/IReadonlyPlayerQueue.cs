using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IReadonlyPlayerQueue<T>
    {
        public T Attacker { get; }
        public T Defender { get; }
        public T Current { get; }

        public bool IsAttackerQueue { get; }
        public bool IsDefenderQueue { get; }

        T GetNextFrom(T player, int andSkip = 0);
    }
}