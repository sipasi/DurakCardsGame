using ProjectCard.DurakModule.StateModule;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public class BattleEndState : DurakState
    {
        public override void Enter()
        {
            base.Enter();

            NextState(DurakGameState.BattleStart);
        }
    }
}