namespace ProjectCard.Shared.Services.TaskModule
{
    public interface ITaskService
    {
        void Execute(float delta);
        void Add(IProcess process);
    }
}