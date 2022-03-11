namespace Framework.Shared.Services.Tasks
{
    public interface ITaskService
    {
        void Execute(float delta);
        void Add(IProcess process);
    }
}