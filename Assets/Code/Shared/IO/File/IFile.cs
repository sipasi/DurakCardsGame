namespace Framework.Shared.IO
{
    public interface IFile<T>
    {
        T Load();

        bool Save(T data);
    }
}
