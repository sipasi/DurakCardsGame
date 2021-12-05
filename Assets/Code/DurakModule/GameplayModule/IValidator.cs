namespace ProjectCard.DurakModule.ValidatorModule
{
    public interface IValidator<T>
    {
        bool Validate(T value);
    }
}