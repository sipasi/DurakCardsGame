
using TMPro;

using UnityEngine;
using UnityEngine.UI;


namespace ProjectCard.Shared.ViewModule
{
    public class DeckView : MonoBehaviour, IDeckView
    {
        [SerializeField] private Image trump;
        [SerializeField] private Image back;
        [SerializeField] private TextMeshProUGUI text;

        public Sprite Trump { get => trump.sprite; set => trump.sprite = value; }
        public Sprite Back { get => back.sprite; set => back.sprite = value; }
        public string Count { get => text.text; set => text.text = value; }
    }
}