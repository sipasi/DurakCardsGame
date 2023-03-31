#nullable enable

using System;

namespace Framework.Shared.Saves
{
    public interface ISaveMetadata
    {
        public string Game { get; }
        public DateTime Date { get; }
    }
}