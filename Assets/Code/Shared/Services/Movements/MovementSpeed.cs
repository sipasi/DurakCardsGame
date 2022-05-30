
using System;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    [Serializable]
    public class MovementSpeed
    {
        [SerializeField] private float value;

        public float Value => value;
    }
}