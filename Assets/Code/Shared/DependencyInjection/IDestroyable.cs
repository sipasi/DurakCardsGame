namespace Framework.Shared.DependencyInjection
{
    public interface IDestroyable
    {
        void Destroy(IDiContainer container);
    }
}