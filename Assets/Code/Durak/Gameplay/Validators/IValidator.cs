namespace Framework.Durak.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T value);
    }
}