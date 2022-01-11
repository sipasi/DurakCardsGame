using System;
using System.Collections.Generic;

using Framework.Durak.Datas;

using Framework.Durak.Players;
using Framework.Shared.Entities;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class PlayerInstaller : IEntityInstaller<PlayerEntity>
    {
        [SerializeField] private string name;
        [SerializeField] private PlayerType type;

        [SerializeField] private Transform place;

        public void Install(PlayerEntity entity)
        {
            IPlayer player = new Player
            {
                Id = Guid.NewGuid(),
                Name = name,
                Type = type,
                Cards = new List<Data>(),
            };

            entity.Initialize(player, place);
        }
    }
}
