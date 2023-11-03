public static class CombatInjector
{
    public static void Inject()
    {
        CombatActionsInjector.Inject();
        ICombatantSystem.Register(new CombatantSystem());
        ICombatResultSystem.Register(new CombatResultSystem());
        IRoundSystem.Register(new RoundSystem());
        ITurnSystem.Register(new TurnSystem());
    }
}