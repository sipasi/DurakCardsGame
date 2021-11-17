using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
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