
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class PlayerPlacesCreator
    {
        [SerializeField] private Transform[] transforms;

        public IReadOnlyList<Transform> Create()
        {
            return transforms;
        }
    }
}