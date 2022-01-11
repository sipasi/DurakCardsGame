using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Entities;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class DiscardPileEntityInstaller : MonoBehaviour, IEntityInstaller<DiscardPileEntity>
    {
        [SerializeField] private PlayingDeckSize size;

        [SerializeField] private Transform place;

        public void Install(DiscardPileEntity entity)
        {
            entity.Initialize(new List<Data>(size.Total), place);
        }
    }
}