
using TMPro;

using UnityEngine;
using UnityEngine.UI;


namespace Framework.Shared.Cards.Views
{
    public class DeckView : IDeckView
    {
        private readonly Image trump;
        private readonly Image back;
        private readonly TextMeshProUGUI text;

        public DeckView(Image trump, Image back, TextMeshProUGUI text)
        {
            this.trump = trump;
            this.back = back;
            this.text = text;
        }

        public Sprite Trump { get => trump.sprite; set => trump.sprite = value; }
        public Sprite Back { get => back.sprite; set => back.sprite = value; }
        public string Count { get => text.text; set => text.text = value; }
    }
}