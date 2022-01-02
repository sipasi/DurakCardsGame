using System.Collections.Generic;

using UnityEngine;

namespace Framework.Shared.Cards.Scriptables
{
    [CreateAssetMenu(fileName = "Pack", menuName = "MyAsset/Shared/Scriptables/SpritePack")]
    public class SpritePack : ScriptableObject
    {
        [SerializeField] private List<Sprite> collection;

        public Sprite this[int index] => collection[index];

        public int Count => collection.Count;

        public List<Sprite>.Enumerator GetEnumerator() => collection.GetEnumerator();
    }
}
