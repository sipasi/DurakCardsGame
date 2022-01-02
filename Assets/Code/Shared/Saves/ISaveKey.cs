namespace Framework.Shared.Saves
{
    public interface ISaveKey<T>
    {
        T Key { get; }
    }
}
