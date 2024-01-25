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
}