
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerPlaceList : MonoBehaviour
    {
        [SerializeField] private List<PlayerPlace> places;

        public PlayerPlace Get(PlayerPosition position)
        {
            foreach (var place in places)
            {
                if (place.Position == position)
                {
                    return place;
                }
            }

            throw new System.ArgumentException();
        }
    }
}