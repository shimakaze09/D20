public static class SoloAdventureInjector
{
    public static void Inject()
    {
        IEncounterSystem.Register(new EncounterSystem());
        IEncounterActionsSystem.Register(new EncounterActionsSystem());
        IEntrySystem.Register(new EntrySystem());
        ISoloHeroSystem.Register(new SoloHeroSystem());
    }
}