
using ProjectCard.Shared.CardModule;

using UnityEngine;

namespace ProjectCard.Shared.ScriptableModule
{
    [CreateAssetMenu(fileName = "CardSelectionInfo", menuName = "MyAsset/Shared/ScriptableModule/CardSelectionInfo")]
    public class CardSelectionInfo : ScriptableObject
    {
        public ICard Card { get; set; }

        public bool Selected => Card == null;

        public void Clear()
        {
            Card = null;
        }
    }
}
