namespace ProjectCard.Durak.ValidatorModule
{
    public interface IValidator<T>
    {
        bool Validate(T value);
    }
}