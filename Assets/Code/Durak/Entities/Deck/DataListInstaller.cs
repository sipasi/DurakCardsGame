
using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Entities;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class DataListInstaller : IEntityInstaller<DataList>
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        public void Install(DataList entity)
        {
            var datas = DataCreator.Create(size.Suits, size.Ranks);

            entity.Initialize(datas);
        }
    }
}