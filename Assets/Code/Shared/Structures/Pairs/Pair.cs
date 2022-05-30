
namespace Framework.Shared.Structures.Pairs
{
    public sealed class Pair<T1, T2> : IPair<T1, T2>
    {
        public T1 First { get; set; }
        public T1 Second { get; set; }
    }
}
