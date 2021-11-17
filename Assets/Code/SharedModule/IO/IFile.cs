#nullable enable


namespace ProjectCard.Shared.IO
{
    public interface IFile
    {
        T Load<T>() where T : class, new();

        bool Save(object data);
    }
}
