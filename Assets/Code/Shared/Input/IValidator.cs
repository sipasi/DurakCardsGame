#nullable enable


namespace Framework.Shared.Input
{
    public interface IValidator<T>
    {
        bool Validate(ref T data);
    }
}