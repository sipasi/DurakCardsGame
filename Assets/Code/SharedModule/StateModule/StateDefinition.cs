using System;

namespace ProjectCard.Shared.StateModule
{
    public interface IStateDefinition
    {
        Type Type { get; }
        IState GetState();
    }

    class StateDefinition<T> : IStateDefinition where T : IState
    {
        private readonly StateFactory<T> factory;
        private readonly Type type;

        public Type Type => type;


        public StateDefinition(StateFactory<T> factory)
        {
            this.factory = factory;
            this.type = typeof(T);
        }


        public IState GetState() => factory.Invoke();
    }
}