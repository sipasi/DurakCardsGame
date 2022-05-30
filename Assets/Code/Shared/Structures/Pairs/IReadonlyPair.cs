
namespace Framework.Shared.Structures.Pairs
{
    public interface IReadonlyPair<T1, T2>
    {
        T1 First { get; }
        T1 Second { get; }
    }
}
