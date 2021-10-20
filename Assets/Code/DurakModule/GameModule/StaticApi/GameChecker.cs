using ProjectCard.DurakModule.PlayerModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule.StaticModule
{
    public static class GameChecker
    {
        public static bool CheckGameOver(PlayerStorage storage)
        {
            var active = storage.Active;

            if (active.Count == 0)
            {
                Debug.Log("Game was end draw");
                return true;
            }

            if (active.Count == 1)
            {
                Debug.Log($"Loser is: {storage.Active[0].Name}");
                return true;
            }

            return false;
        }
    }
}