
namespace Framework.Shared.Structures.Links
{
    public interface IReadonlyLink<TKey, TValue>
    {
        TValue Value { get; }
    }
}
