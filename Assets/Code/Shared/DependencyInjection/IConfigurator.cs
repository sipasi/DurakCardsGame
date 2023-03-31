namespace Framework.Shared.DependencyInjection
{
    public interface IConfigurator
    {
        void Configure(ServiceBuilder builder);
    }
}