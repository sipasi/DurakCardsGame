using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Creators
{
    [Serializable]
    internal class PlayerListCreator
    {
        [SerializeField] private Info top;
        [SerializeField] private Info bottom;

        public IReadOnlyList<IPlayer> Create()
        {
            IPlayer[] players = new Info[] { top, bottom }.Select(static info => new Player
            {
                Id = Guid.NewGuid(),
                Name = info.name,
                Type = info.type,

                Owner = new CardOwner(info.transform),

                Hand = new Hand(info.lookSide),
            }).ToArray();

            return players;
        }

        [Serializable]
        private struct Info
        {
            public string name;
            public PlayerType type;
            public CardLookSide lookSide;
            public Transform transform;
        }
    }
}