using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;

using System.Collections.Generic;

namespace Framework.Durak.Players.Selectors
{
    public abstract class AiCardSelector : CardSelector
    {
        public abstract ICard GetCard(IReadOnlyList<Data> hand);

        public sealed override void Begin()
        {
            base.Begin();

            IPlayer player = Current;

            ICard card = GetCard(player.Hand);

            if (card == null)
            {
                Pass();

                return;
            }

            SelectCard(card);
        }
        public sealed override void End() => base.End();
    }
}