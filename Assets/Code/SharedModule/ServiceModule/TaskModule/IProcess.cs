
namespace ProjectCard.Shared.ServiceModule.TaskModule
{
    public interface IProcess
    {
        bool Finished { get; }
        void Execute(float delta);
    }
}