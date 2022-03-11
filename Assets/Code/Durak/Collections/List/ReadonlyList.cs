using Framework.Shared.Collections;

using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Framework.Durak.Collections
{
    public class ReadonlyList<T> : MonoBehaviour
    {
        private IReadOnlyList<T> collection;

        public IReadOnlyList<T> Value => collection;

        public void Initialize(IReadOnlyList<T> list) => this.collection = list;

        public bool Contains(T item) => collection.Contains(item);

        public ListEnumerator<T> GetEnumerator() => new ListEnumerator<T>(collection);
    }

}
