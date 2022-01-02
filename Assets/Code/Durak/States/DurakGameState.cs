namespace Framework.Durak.States
{
    public enum DurakGameState
    {
        GameStart,
        GameEnd,

        BattleFirstStart,
        BattleStart,
        BattleAttackerWinner,
        BattleDefenderWinner,
        BattleEnd,

        Toss,

        DefinePlayerAction,
        PlayerAttacking,
        PlayerDefending,

        GameRestart,
    }
}