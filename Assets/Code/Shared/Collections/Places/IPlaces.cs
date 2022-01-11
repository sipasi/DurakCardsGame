namespace Framework.Shared.Collections
{
    public interface IPlaces<T>
    {
        T Place();
        T ToAttacks();
        T ToDefends();

        void Clear();
    }
}