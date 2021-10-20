
using UnityEngine;

namespace ProjectCard.Shared.CardModule
{
    [CreateAssetMenu(fileName = "DeckSize", menuName = "MyAsset/Shared/ScriptableModule/DeckSize")]
    public class PlayingDeckSize : ScriptableObject
    {
        [SerializeField] private int suits;
        [SerializeField] private int ranks;

        public int Suits => suits;
        public int Ranks => ranks;
        public int Total => suits + ranks;


        public void Deconstruct(out int suits, out int ranks)
        {
            suits = this.suits;
            ranks = this.ranks;
        }
        public void Deconstruct(out int suits, out int ranks, out int total)
        {
            suits = this.suits;
            ranks = this.ranks;
            total = suits + ranks;
        }
    }
}