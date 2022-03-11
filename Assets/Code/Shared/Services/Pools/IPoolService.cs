namespace Framework.Shared.Services.Pools
{
    public interface IPoolService
    {
        T Get<T>() where T : class, new();
        void Return<T>(T item) where T : class;
        void Clear();
    }
}