public static class Injector
{
    public static void Inject()
    {
        // These Must Be First
        // -------------------
        ISetUpSystem.Register(new SetUpSystem());
        ITearDownSystem.Register(new TearDownSystem());

        // Order doesn't matter
        // --------------------
        ActionInjector.Inject();
        AssetManagerInjector.Inject();
        BoardInjector.Inject();
        CombatInjector.Inject();
        ComponentInjector.Inject();
        DataInjector.Inject();
        DiceRollInjector.Inject();
        EntityInjector.Inject();
        FlowInjector.Inject();
        IGameSystem.Register(new GameSystem());
        IInputSystem.Register(new InputSystem());
        SoloAdventureInjector.Inject();
    }
}