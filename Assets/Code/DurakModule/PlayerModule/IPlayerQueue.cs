namespace ProjectCard.DurakModule.PlayerModule
{
    public interface IPlayerQueue
    {
        public PlayerActionType Action { get; }

        public IPlayer Attacker { get; }
        public IPlayer Defender { get; }
        public IPlayer Current { get; }

        public bool IsAttackerQueue { get; }
        public bool IsDefenderQueue { get; }

        public void Set(IPlayer attacker, IPlayer defender, PlayerActionType action);

        public void SwitchActionType();

        IPlayer GetNextFrom(IPlayer player, int andSkip = 0);
    }
}