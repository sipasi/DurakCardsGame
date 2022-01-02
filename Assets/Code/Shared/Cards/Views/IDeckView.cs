
using UnityEngine;


namespace Framework.Shared.Cards.Views
{
    public interface IDeckView
    {
        Sprite Trump { get; set; }
        Sprite Back { get; set; }
        string Count { get; set; }
    }
}