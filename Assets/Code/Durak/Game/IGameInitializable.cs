using Framework.Durak.Saves;
using Framework.Shared.DependencyInjection;

namespace Framework.Durak.Game
{
    public interface IGameInitializable
    {
        void Initialize(IDiContainer container);
    }
}