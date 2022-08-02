#nullable enable


namespace Framework.Shared.Input
{
    public interface IInputHandler<T>
    {
        void Handle(ref T data);
    }
}