
namespace Framework.Shared.Structures.Links
{
    public sealed class Link<TKey, TValue> : ILink<TKey, TValue>
    {
        public Link() { }
        public Link(TValue value) => Value = value;

        public TValue Value { get; set; }
    }
}
