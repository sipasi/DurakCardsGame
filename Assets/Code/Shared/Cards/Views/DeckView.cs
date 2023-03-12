using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Shared.Cards.Views
{
    public interface IDeckView
    {
        Sprite Trump { get; set; }
        Sprite Back { get; set; }

        string Text { get; set; }
    }

    public class DeckView : IDeckView
    {
        private readonly Image trump;
        private readonly Image back;
        private readonly TextMeshProUGUI text;

        public Sprite Trump { get => trump.sprite; set => trump.sprite = value; }
        public Sprite Back { get => back.sprite; set => back.sprite = value; }

        public string Text { get => text.text; set => text.text = value; }

        public DeckView(Image trump, Image back, TextMeshProUGUI text)
        {
            this.trump = trump;
            this.back = back;
            this.text = text;
        }
    }
}