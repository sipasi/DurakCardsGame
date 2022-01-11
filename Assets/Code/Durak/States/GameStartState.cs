using Framework.Durak.Entities;

using UnityEngine;

namespace Framework.Durak.States
{
    public class GameStartState : DurakState
    {
        [Header("Entities")]
        [SerializeField] private DeckEntity deck;

        public override void Enter()
        {
            base.Enter();

            deck.Shuffle(times: 500);

            NextState(DurakGameState.BattleFirstStart);
        }
    }
}