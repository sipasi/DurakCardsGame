using System;

namespace Framework.Shared.Saves
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