
namespace Framework.Shared.Structures.Links
{
    public interface ILink<TKey, TValue> : IReadonlyLink<TKey, TValue>
    {
        new TValue Value { set; }
    }
}
