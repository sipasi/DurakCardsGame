using System;

using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Game.EntityCreators
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