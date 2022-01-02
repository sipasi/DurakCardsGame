namespace Framework.Shared.Collections
{
    public interface IIndexCollection : IReadonlyIndexCollection
    {
        int Next();

        int Peek();
        int Peek(int offset);
        int PeekFirst();

        void Fill();

        void Randomize(int times);
        void Randomize(int from, int times);

        void ResetIndex();
    }
}