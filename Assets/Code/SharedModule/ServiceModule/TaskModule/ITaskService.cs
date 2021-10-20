namespace ProjectCard.Shared.ServiceModule.TaskModule
{
    public interface ITaskService
    {
        void Execute(float delta);
        void Add(IProcess process);
    }
}