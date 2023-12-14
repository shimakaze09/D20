public static class SoloAdventureInjector
{
    public static void Inject()
    {
        ICombatantAssetSystem.Register(new CombatantAssetSystem());
        ICombatantViewSystem.Register(new CombatantViewSystem());
        IEncounterActionsSystem.Register(new EncounterActionsSystem());
        IEncounterSystem.Register(new EncounterSystem());
        IEntrySystem.Register(new EntrySystem());
        IPhysicsSystem.Register(new PhysicsSystem());
        IPositionSelectionSystem.Register(new PositionSelectionSystem());
        ISoloHeroSystem.Register(new SoloHeroSystem());
    }

    public static void SetUp()
    {
        ICombatantAssetSystem.Resolve().SetUp();
        ICombatantViewSystem.Resolve().SetUp();
        IEncounterActionsSystem.Resolve().SetUp();
        IEncounterSystem.Resolve().SetUp();
        IEntrySystem.Resolve().SetUp();
        IPhysicsSystem.Resolve().SetUp();
        IPositionSelectionSystem.Resolve().SetUp();
        ISoloHeroSystem.Resolve().SetUp();
    }

    public static void TearDown()
    {
        ICombatantAssetSystem.Resolve().TearDown();
        ICombatantViewSystem.Resolve().TearDown();
        IEncounterActionsSystem.Resolve().TearDown();
        IEncounterSystem.Resolve().TearDown();
        IEntrySystem.Resolve().TearDown();
        IPhysicsSystem.Resolve().TearDown();
        IPositionSelectionSystem.Resolve().TearDown();
        ISoloHeroSystem.Resolve().TearDown();
    }
}