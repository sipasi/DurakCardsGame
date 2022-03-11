
namespace Framework.Shared.Services.Tasks
{
    public interface IProcess
    {
        bool Finished { get; }
        void Execute(float delta);
    }
}