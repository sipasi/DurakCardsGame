

using System;

using ProjectCard.Shared.CoreModule.AttributeModule;

using UnityEngine;

namespace ProjectCard.Shared.SaveModule
{
    [CreateAssetMenu(fileName = "SaveKey", menuName = "MyAsset/Shared/SaveModule/SaveKey by Guid")]
    public class SaveKey : ScriptableObject, ISaveKey<Guid>
    {
        private Guid guid;
        [SerializeField, ReadOnlyField] private string text = string.Empty;

        public Guid Key
        {
            get
            {
                if (guid == Guid.Empty)
                {
                    bool isNullOrEmpty = string.IsNullOrEmpty(text);

                    Key = new Guid(text);
                }

                return guid;
            }
            private set
            {
                guid = value;
                text = value.ToString();
            }
        }

        public override string ToString() => text;

        private void GenerateNewKey()
        {
            Key = Guid.NewGuid();
        }
    }
}