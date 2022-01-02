
namespace Framework.Shared.Collections
{
    public interface IReadonlyStorage<TKey>
    {
        public int Count { get; }

        bool Contains(TKey key);
    }
}
