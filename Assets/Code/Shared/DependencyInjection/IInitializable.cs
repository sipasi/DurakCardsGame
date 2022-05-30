namespace Framework.Shared.DependencyInjection
{
    public interface IInitializable
    {
        void Initialize(IDiContainer container);
    }
}