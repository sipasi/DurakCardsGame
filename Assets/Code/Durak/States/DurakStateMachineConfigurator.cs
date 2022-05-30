using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.States;

namespace Framework.Durak.States
{
    internal class DurakStateMachineConfigurator : ServiceConfigurator
    {
        private readonly StatesConfigurator statesConfigurator = new StatesConfigurator();

        public override void Configure(ServiceBuilder builder)
        {
            var singleton = builder.singleton;

            var machine = new StateMachine<DurakGameState>();

            singleton.Add<IStateMachine<DurakGameState>>(machine);
            singleton.Add<IStateMachineDefinition<DurakGameState>>(machine);

            statesConfigurator.Configure(builder);
        }
    }
}