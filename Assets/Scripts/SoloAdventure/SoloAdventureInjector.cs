﻿public class SoloAdventureInjector
{
    public static void Inject()
    {
        IEntrySystem.Register(new EntrySystem());
    }
}