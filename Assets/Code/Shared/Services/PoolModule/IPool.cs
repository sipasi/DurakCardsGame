namespace Framework.Shared.Services.Pools
{
    public interface IPool
    {
        T Get<T>() where T : class, new();
        void Return<T>(T item) where T : class;
        void Clear();
    }
}