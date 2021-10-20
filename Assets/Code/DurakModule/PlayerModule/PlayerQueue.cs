
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerQueue : MonoBehaviour
    {
        [SerializeField] private PlayerStorage storage;

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

        public PlayerInfo Attacker { get; private set; }
        public PlayerInfo Defender { get; private set; }
        public PlayerInfo Current { get; private set; }

        public bool IsAttackerQueue => Current == Attacker;
        public bool IsDefenderQueue => Current == Defender;


        private void Awake()
        {
            Assert.IsNotNull(storage, $"You have forgotten set the {nameof(PlayerStorage)} reference");
        }


        public void Set(PlayerInfo attacker, PlayerInfo defender, PlayerActionType action)
        {
            Attacker = attacker;
            Defender = defender;

            Action = action;
        }

        public void SwitchActionType()
        {
            Action = Action == PlayerActionType.Attack ? PlayerActionType.Defend : PlayerActionType.Attack;
        }

        public PlayerInfo GetNextFrom(PlayerInfo player, int andSkip = 0)
        {
            IReadOnlyList<PlayerInfo> active = storage.Active;

            int index = storage.IndexOf(player);

            int next = (index + 1 + andSkip) % active.Count;

            return active[next];
        }
    }
}