namespace Framework.Durak.Validators
{
    public interface IPlayerActionValidator<T>
    {
        IValidator<T> Attacking { get; }
        IValidator<T> Defending { get; }
    }
}