
using System;
using System.Collections.Generic;

namespace ProjectCard.DurakModule.PlayerModule
{
    [Serializable]
    public class PlayerQueue : IPlayerQueue
    {
        private IPlayerStorage storage;

        private PlayerActionType action;

        public PlayerActionType Action
        {
            get => action;
            private set
            {
                action = value;

                Current = value switch
                {
                    PlayerActionType.Attack => Attacker,
                    PlayerActionType.Defend => Defender,
                    _ => throw new System.NotImplementedException(),
                };
            }
        }

        public IPlayer Attacker { get; private set; }
        public IPlayer Defender { get; private set; }
        public IPlayer Current { get; private set; }

        public bool IsAttackerQueue => Current == Attacker;
        public bool IsDefenderQueue => Current == Defender;


        public PlayerQueue(IPlayerStorage storage)
        {
            this.storage = storage;
        }


        public void Set(IPlayer attacker, IPlayer defender, PlayerActionType action)
        {
            Attacker = attacker;
            Defender = defender;

            Action = action;
        }

        public void SwitchActionType()
        {
            Action = Action == PlayerActionType.Attack ? PlayerActionType.Defend : PlayerActionType.Attack;
        }

        public IPlayer GetNextFrom(IPlayer player, int andSkip = 0)
        {
            IReadOnlyList<IPlayer> active = storage.Active;

            int index = storage.IndexOf(player);

            int next = (index + 1 + andSkip) % active.Count;

            return active[next];
        }
    }
}