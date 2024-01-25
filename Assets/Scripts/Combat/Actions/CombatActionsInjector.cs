public static class CombatActionsInjector
{
    public static void Inject()
    {
        IAttackRollSystem.Register(new AttackRollSystem());
        IStrideSystem.Register(new StrideSystem());
    }
}