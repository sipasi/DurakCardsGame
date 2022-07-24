
using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class DurakGame : MonoBehaviour
    {
        [SerializeField] private DurakNewGameLoader newGameLoader;

        public UniTask LoadNewGame()
        {
            newGameLoader.Load();

            return UniTask.CompletedTask;
        }
        public UniTask UnloadGame()
        {
            return UniTask.CompletedTask;
        }
    }
}