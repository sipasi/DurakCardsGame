
using UnityEngine;

namespace ProjectCard.Shared.ScriptableModule
{
    [CreateAssetMenu(fileName = "CardTheme", menuName = "MyAsset/Shared/Scriptables/CardTheme")]
    public class CardTheme : ScriptableObject
    {
        [Header("Sprites")]
        [SerializeField] private SpritePack faces;
        [SerializeField] private SpritePack backs;
        [SerializeField] private int backIndex;

        public SpritePack Faces => faces;
        public SpritePack Backs => backs;
        public Sprite Back => backs[backIndex];


        private void OnValidate()
        {
            if (backs != null)
            {
                if (backIndex < 0)
                {
                    backIndex = 0;
                }
                else if (backIndex >= backs.Count)
                {
                    backIndex = backs.Count - 1;
                }
            }
        }
    }
}
