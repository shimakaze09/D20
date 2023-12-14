public static class CombatInjector
{
    public static void Inject()
    {
        CombatActionsInjector.Inject();
        ICombatantSystem.Register(new CombatantSystem());
        ICombatResultSystem.Register(new CombatResultSystem());
        DamageInjector.Inject();
        IRoundSystem.Register(new RoundSystem());
        ITurnSystem.Register(new TurnSystem());
    }

    public static void SetUp()
    {
        CombatActionsInjector.SetUp();
        ICombatantSystem.Resolve().SetUp();
        ICombatResultSystem.Resolve().SetUp();
        DamageInjector.SetUp();
        IRoundSystem.Resolve().SetUp();
        ITurnSystem.Resolve().SetUp();
    }

    public static void TearDown()
    {
        CombatActionsInjector.TearDown();
        ICombatantSystem.Resolve().TearDown();
        ICombatResultSystem.Resolve().TearDown();
        DamageInjector.TearDown();
        IRoundSystem.Resolve().TearDown();
        ITurnSystem.Resolve().TearDown();
    }
}