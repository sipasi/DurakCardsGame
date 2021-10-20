
using System;

using UnityEngine;

namespace ProjectCard.DurakModule.ViewModule
{
    public class BoardPlaces : MonoBehaviour
    {
        [SerializeField] private Place[] places;

        private int index;

        public Place Current => places[index];


        public void Next()
        {
            index++;
        }

        public void Clear()
        {
            index = 0;
        }


        [Serializable]
        public struct Place
        {
            [SerializeField] private Transform attacker;
            [SerializeField] private Transform defender;

            public Transform Attacker => attacker;
            public Transform Defender => defender;
        }
    }
}