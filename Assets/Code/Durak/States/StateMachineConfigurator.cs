using Framework.Shared.DependencyInjection;
using Framework.Shared.States;

namespace Framework.Durak.States
{
    public class StateMachineConfigurator
    {
        private readonly StatesConfigurator statesConfigurator = new StatesConfigurator();

        public void Configure(ServiceBuilder builder)
        {
            var singleton = builder.singleton;

            var machine = new StateMachine<DurakGameState>();

            singleton.Add<IStateMachine<DurakGameState>>(machine);
            singleton.Add<IStateMachineDefinition<DurakGameState>>(machine);

            statesConfigurator.Configure(builder);
        }
    }
}