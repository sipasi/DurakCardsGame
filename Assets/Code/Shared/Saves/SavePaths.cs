#nullable enable

using System.IO;

using UnityEngine;

namespace Framework.Shared.Saves
{
    public static class SavePaths
    {
        private static readonly string directory = Path.Combine(Application.persistentDataPath, "Saves");

        public static readonly Info durak = new(directory, "durak.save");

        public readonly struct Info
        {
            public readonly string path;

            public Info(string directory, string name) => path = Path.Combine(directory, name);

            public bool Exists => File.Exists(path);
        }
    }
}