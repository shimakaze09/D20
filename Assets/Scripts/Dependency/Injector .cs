public static class Injector
{
    public static void Inject()
    {
        ComponentInjector.Inject();
        DataInjector.Inject();
        DiceRollInjector.Inject();
        IEntitySystem.Register(new EntitySystem());
        FlowInjector.Inject();
    }
}