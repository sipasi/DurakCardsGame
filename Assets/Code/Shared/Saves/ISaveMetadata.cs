#nullable enable

using System;
using System.Threading.Tasks;

namespace Framework.Shared.Saves
{
    public interface ISaveMetadata
    {
        public string Game { get; }
        public DateTime Date { get; }
    }
}