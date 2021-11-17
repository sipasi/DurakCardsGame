using System.Collections.Generic;

using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;
using UnityEngine.Assertions;

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