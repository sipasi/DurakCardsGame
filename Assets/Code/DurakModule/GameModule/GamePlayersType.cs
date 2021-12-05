
using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    [CreateAssetMenu(fileName = "GamePlayersType", menuName = "MyAsset/Durak/GameModule/GamePlayersType")]
    public class GamePlayersType : ScriptableObject
    {
        [field: SerializeField] public PlayersType PlayersType { get; set; }
    }
}