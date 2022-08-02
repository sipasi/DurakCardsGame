namespace Framework.Durak.Players.Selectors
{
    public class RealInputCardSelector : CardSelector
    {
        private readonly IRealInputListener listener;

        public RealInputCardSelector(IRealInputListener listener)
        {
            this.listener = listener;
        }

        public override void Begin()
        {
            base.Begin();

            listener.Tapped += SelectCard;
            listener.Passed += Pass;
        }
        public override void End()
        {
            base.End();

            listener.Tapped -= SelectCard;
            listener.Passed -= Pass;
        }
    }
}