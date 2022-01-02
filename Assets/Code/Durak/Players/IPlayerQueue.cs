namespace Framework.Durak.Players
{
    public interface IPlayerQueue
    {
        public PlayerActionType Action { get; set; }

        public IPlayer Attacker { get; }
        public IPlayer Defender { get; }
        public IPlayer Current { get; }

        public bool IsAttackerQueue { get; }
        public bool IsDefenderQueue { get; }

        public void Set(IPlayer attacker, IPlayer defender, PlayerActionType action);

        IPlayer GetNextFrom(IPlayer player, int andSkip = 0);
    }
}