using System.Collections.Generic;

using ProjectCard.Shared.Services.CollectionModule;

namespace ProjectCard.Shared.Services.TaskModule
{
    public class Parallel : IProcess, IReusable
    {
        private readonly List<IProcess> collection;

        public bool Finished => collection.Count == 0;


        public Parallel() : this(6) { }
        public Parallel(int capacity) => collection = new List<IProcess>(capacity);


        public void Add(IProcess process) => collection.Add(process);
        public void AddRange(IEnumerable<IProcess> processes) => collection.AddRange(processes);

        public void Execute(float delta)
        {
            int count = collection.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                var process = collection[i];

                if (process.Finished)
                {
                    collection.RemoveAt(i);

                    continue;
                }

                process.Execute(delta);
            }
        }

        void IReusable.Reuse()
        {
            collection.Clear();
        }
    }
}