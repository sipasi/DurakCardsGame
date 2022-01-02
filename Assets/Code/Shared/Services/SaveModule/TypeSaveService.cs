

using System;

using UnityEngine;

namespace Framework.Shared.Services.Saves
{
    [CreateAssetMenu(fileName = "TypeSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by Type")]
    public sealed class TypeSaveService : SaveStorageService<Type>
    {
        public T Restore<T>() where T : class => Restore<T>(key: typeof(T));

        public void Store<T>(T data) where T : class => Store(key: typeof(T), data);

        public bool Contains<T>() => Contains(typeof(T));
    }
}