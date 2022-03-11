using Cysharp.Threading.Tasks;


namespace Framework.Durak.Gameplay
{
    public interface ICardDealer
    {
        UniTask DealCard();
    }
}