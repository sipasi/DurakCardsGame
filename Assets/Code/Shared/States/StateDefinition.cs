using System;

namespace Framework.Shared.States
{
    public interface IStateDefinition
    {
        Type Type { get; }
        IState GetState();
    }

    internal class StateDefinition<T> : IStateDefinition where T : IState
    {
        private readonly StateFactory<T> factory;
        private readonly Type type;

        public Type Type => type;


        public StateDefinition(StateFactory<T> factory)
        {
            this.factory = factory;
            type = typeof(T);
        }


        public IState GetState() => factory.Invoke();
    }
}