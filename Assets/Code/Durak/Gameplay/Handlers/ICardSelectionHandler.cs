
using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;

namespace Framework.Durak.Gameplay.Handlers
{
    public interface ICardSelectionHandler
    {
        UniTask<bool> Handle(ICard card);
    }
}