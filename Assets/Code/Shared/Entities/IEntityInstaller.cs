
namespace Framework.Shared.Entities
{
    public interface IEntityInstaller<T>
    {
        void Install(T entity);
    }
}