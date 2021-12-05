

using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.Shared.SaveModule
{
    public interface ISavableEntity<TKey>
    {
        void Save(IStorage<TKey> storage);
    }
}
