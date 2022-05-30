
namespace Framework.Shared.Structures.Pairs
{
    public interface IPair<T1, T2> : IReadonlyPair<T1, T2>
    {
        new T1 First { set; }
        new T1 Second { set; }
    }
}
