using Framework.Shared.Collections;

using System;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class PlacesCreator
    {
        [SerializeField] private Places<Transform>.Pair[] pairs;

        public IPlaces<Transform> Create()
        {
            return new Places<Transform>(pairs);
        }
    }
}