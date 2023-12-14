public static class CombatActionsInjector
{
    public static void Inject()
    {
        IAttackRollSystem.Register(new AttackRollSystem());
        IStrideSystem.Register(new StrideSystem());
    }

    public static void SetUp()
    {
        IAttackRollSystem.Resolve().SetUp();
        IStrideSystem.Resolve().SetUp();
    }

    public static void TearDown()
    {
        IAttackRollSystem.Resolve().TearDown();
        IStrideSystem.Resolve().TearDown();
    }
}