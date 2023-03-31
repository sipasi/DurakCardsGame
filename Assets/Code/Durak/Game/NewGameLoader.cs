using Framework.Durak.Game.DependencyInjection;
using Framework.Durak.States;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Events;

namespace Framework.Durak.Game
{
    public class NewGameLoader : GameLoader
    {
        public NewGameLoader(ScriptableAction restart) : base(restart) { }

        protected override IDiContainer CreateDiContainer()
        {
            return DiContainerConfigurator.BuildForNewGame();
        }

        protected override DurakGameState GetState() => DurakGameState.GameStart;
    }
}