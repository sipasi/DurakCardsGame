
using Cysharp.Threading.Tasks;

using UnityEngine;

namespace ProjectCard.Shared.GameModule
{
    public abstract class GameLoader : MonoBehaviour
    {
        public abstract UniTask LoadNewGame();
        public abstract UniTask LoadSavedGame();
    }
}
