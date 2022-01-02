using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Durak.Cards.Selectors
{
    public class RealInputCardSelector : CardSelector
    {
        [SerializeField] private ScriptableAction<ICard> cardClicked;
        [SerializeField] private ScriptableAction passClicked;

        public override void Begin()
        {
            base.Begin();

            cardClicked.Action += SelectCard;
            passClicked.Action += Pass;
        }
        public override void End()
        {
            base.End();

            cardClicked.Action -= SelectCard;
            passClicked.Action -= Pass;
        }
    }
}