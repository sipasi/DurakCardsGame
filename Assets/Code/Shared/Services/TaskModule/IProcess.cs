
namespace ProjectCard.Shared.Services.TaskModule
{
    public interface IProcess
    {
        bool Finished { get; }
        void Execute(float delta);
    }
}