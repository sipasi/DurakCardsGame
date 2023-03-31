using System.IO;

using Framework.Shared.Events;
using Framework.Shared.Saves;

using UnityEngine;

namespace Framework.Durak.Game
{
    internal class Startup : MonoBehaviour
    {
        private IGameLoader game;

        [SerializeField] private ScriptableAction restart;

        [SerializeField] private bool forceLoad = false;
        [SerializeField] private LoadGameType loadGame;

        private async void Start()
        {
            game = forceLoad
                ? ForceLoad(restart, loadGame)
                : Load(restart);

            await game.Load();
        }
        private async void OnDestroy()
        {
            await game.Unload();
        }

        private static IGameLoader Load(ScriptableAction restart)
        {
            bool exist = File.Exists(SavePaths.durak.path);

            return exist switch
            {
                true => new SavedGameLoader(restart),
                false => new NewGameLoader(restart),
            };
        }

        private static IGameLoader ForceLoad(ScriptableAction restart, LoadGameType gameType)
        {
            bool exist = File.Exists(SavePaths.durak.path);

            if (gameType is LoadGameType.Saved && exist is false)
            {
                Debug.Log("Can't load saved game, because file doesn't exist");

                return new NewGameLoader(restart);
            }

            return gameType switch
            {
                LoadGameType.New => new NewGameLoader(restart),
                LoadGameType.Saved => new SavedGameLoader(restart),

                _ => throw new System.NotImplementedException()
            };
        }

        private enum LoadGameType
        {
            New,
            Saved
        }
    }
}