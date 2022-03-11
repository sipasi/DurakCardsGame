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

            listener.Selected += SelectCard;
            listener.Passed += Pass;
        }
        public override void End()
        {
            base.End();

            listener.Selected -= SelectCard;
            listener.Passed -= Pass;
        }
    }
}