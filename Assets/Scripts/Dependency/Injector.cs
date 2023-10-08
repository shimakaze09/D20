public static class Injector
{
    public static void Inject()
    {
        AssetManagerInjector.Inject();
        ComponentInjector.Inject();
        DataInjector.Inject();
        DiceRollInjector.Inject();
        EntityInjector.Inject();
        FlowInjector.Inject();
        IGameSystem.Register(new GameSystem());
        SoloAdventureInjector.Inject();
    }
}