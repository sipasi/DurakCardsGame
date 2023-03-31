using Framework.Durak.Saves;
using Framework.Shared.DependencyInjection;

namespace Framework.Durak.Game
{
    public interface IGameConfigurator { }
    public interface IIdenticalGameConfigurator : IGameConfigurator
    {
        void Configure(ServiceBuilder builder);
    }
    public interface INewGameConfigurator : IGameConfigurator
    {
        void Configure(ServiceBuilder builder);
    }
    public interface ISavedGameConfigurator : IGameConfigurator
    {
        void Configure(ServiceBuilder builder, SaveData data);
    }
}