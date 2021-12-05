

using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.Shared.SaveModule
{
    public interface ILoadableEntity<TKey>
    {
        void Load(IStorage<TKey> storage);
    }
}