using System;

namespace ProjectCard.Shared.SaveModule
{
    [Serializable]
    public class SaveInfo
    {
        public DateTime Created { get; }
        public string Title { get; }

        public SaveInfo(string title)
        {
            Title = title;
            Created = DateTime.Now;
        }
    }
}