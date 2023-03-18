using Framework.Shared.DependencyInjection;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.States
{
    internal class DurakStateMachineConfigurator : MonoBehaviour, IConfigurator
    {
        private readonly StatesConfigurator statesConfigurator = new();

        public void Configure(ServiceBuilder builder)
        {
            var singleton = builder.singleton;

            var machine = new StateMachine<DurakGameState>();

            singleton.Add<IStateMachine<DurakGameState>>(machine);
            singleton.Add<IStateTriggerInfo<DurakGameState>>(machine);
            singleton.Add<IStateMachineDefinition<DurakGameState>>(machine);

            statesConfigurator.Configure(builder);
        }
    }
}