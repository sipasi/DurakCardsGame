
using UnityEngine;


namespace ProjectCard.Shared.ViewModule
{
    public interface IDeckView
    {
        Sprite Trump { get; set; }
        Sprite Back { get; set; }
        string Count { get; set; }
    }
}