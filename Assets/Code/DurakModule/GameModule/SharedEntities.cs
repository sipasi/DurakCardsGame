
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class SharedEntities : MonoBehaviour
    {
        public Deck<Data> Deck { get; private set; }
        public Board<Data> Board { get; private set; }

        public void Initialize(Data[] datas, int boardRowItemsCount)
        {
            Deck = new Deck<Data>(datas);
            Board = new Board<Data>(boardRowItemsCount);
        }
    }
}