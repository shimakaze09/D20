public static class CombatActionsInjector
{
    public static void Inject()
    {
        IStrideSystem.Register(new StrideSystem());
    }
}