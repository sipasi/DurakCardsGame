#nullable enable 


namespace ProjectCard.Shared.SaveModule
{
    public interface ISaveKey<T>
    {
        T Key { get; }
    }

}
