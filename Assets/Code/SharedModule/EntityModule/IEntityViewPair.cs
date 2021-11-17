namespace ProjectCard.Shared.EntityModule
{
    public interface IEntityViewPair<TEntity, TView>
    {
        TEntity Entity { get; }
        TView View { get; }
    }
}