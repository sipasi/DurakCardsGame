using UnityEngine;
using UnityEngine.UI;

namespace Framework.Shared.Cards.Views
{
    public interface ICardView
    {
        public Sprite Face { get; set; }
        public Sprite Back { get; set; }

        bool IsVisible { get; set; }
        CardLookSide LookSide { get; set; }
    }

    public class CardView : ICardView
    {
        private readonly Image source;

        private Sprite face;
        private Sprite back;

        public Sprite Face
        {
            get => face;
            set
            {
                face = value;

                if (LookSide is CardLookSide.Face)
                {
                    source.sprite = value;
                }
            }
        }
        public Sprite Back
        {
            get => back;
            set
            {
                back = value;

                if (LookSide is CardLookSide.Back)
                {
                    source.sprite = value;
                }
            }
        }

        public bool IsVisible
        {
            get => source.color != Color.clear;
            set => source.color = value ? Color.white : Color.clear;

        }
        public CardLookSide LookSide
        {
            get => source.sprite == face ? CardLookSide.Face : CardLookSide.Back;
            set => source.sprite = value == CardLookSide.Face ? face : back;
        }

        public CardView(Image source, Sprite face, Sprite back)
        {
            this.source = source;
            this.face = face;
            this.back = back;
        }
    }
}