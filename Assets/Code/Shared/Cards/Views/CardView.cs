
using UnityEngine;
using UnityEngine.UI;


namespace Framework.Shared.Cards.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image source;

        private Sprite face;
        private Sprite back;

        [SerializeField] private CardLookSide look;
        [SerializeField] private bool visible = true;

        public Sprite Face
        {
            get => face;
            set
            {
                face = value;

                if (look == CardLookSide.Face)
                {
                    source.sprite = face;
                }
            }
        }
        public Sprite Back
        {
            get => back;
            set
            {
                back = value;

                if (look == CardLookSide.Back)
                {
                    source.sprite = back;
                }
            }
        }

        public bool IsVisible
        {
            get => visible;
            set
            {
                visible = value;
                source.color = value ? Color.white : Color.clear;
            }
        }
        public CardLookSide LookSide
        {
            get => look;
            set
            {
                look = value;

                var gameObject = this.gameObject;
                var na = gameObject.name;

                source.sprite = value == CardLookSide.Face ? face : back;
            }
        }

        private void OnValidate()
        {
            LookSide = look;
            IsVisible = visible;
        }
    }
}