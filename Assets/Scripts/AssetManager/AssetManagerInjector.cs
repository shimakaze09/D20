public static class AssetManagerInjector
{
    public static void Inject()
    {
        IAncestryAssetSystem.Register(new AncestryAssetSystem());
        ICombatActionAssetSystem.Register(new CombatActionAssetSystem());
        IEncounterAssetSystem.Register(new EncounterAssetSystem());
        IEntryAssetSystem.Register(new EntryAssetSystem());
    }
}