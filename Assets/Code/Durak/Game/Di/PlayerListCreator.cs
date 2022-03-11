using Framework.Durak.Players;
using Framework.Shared.Cards.Views;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class PlayerListCreator
    {
        [SerializeField] private Pair top;
        [SerializeField] private Pair bottom;

        public IReadOnlyList<IPlayer> Create()
        {
            var players = new IPlayer[]
            {
                new Player
                {
                    Id = Guid.NewGuid(),
                    Name = top.name,
                    Type = top.type,
                    Hand = new Hand(CardLookSide.Back),
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    Name = bottom.name,
                    Type = bottom.type,
                    Hand = new Hand(CardLookSide.Face),
                }
            };

            return players;
        }

        [Serializable]
        private struct Pair
        {
            public string name;
            public PlayerType type;
        }
    }
}