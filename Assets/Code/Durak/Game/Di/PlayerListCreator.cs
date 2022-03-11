using Framework.Durak.Players;
using Framework.Shared.Cards.Views;

using System;
using System.Collections.Generic;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class PlayerListCreator
    {
        public IReadOnlyList<IPlayer> Create()
        {
            var players = new IPlayer[]
            {
                new Player
                {
                    Id = Guid.NewGuid(),
                    Name = "Savva",
                    Hand = new Hand(CardLookSide.Back),
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    Name = "Sasha",
                    Hand = new Hand(CardLookSide.Face),
                }
            };

            return players;
        }
    }
}