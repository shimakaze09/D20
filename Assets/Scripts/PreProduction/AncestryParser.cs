using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AncestryParser
{
    [MenuItem("Pre Production/Generate/Ancestries")]
    public static void GenerateAll()
    {
        if (!AssetDatabase.IsValidFolder("Assets/AutoGeneration"))
            AssetDatabase.CreateFolder("Assets", "AutoGeneration");
        if (!AssetDatabase.IsValidFolder("Assets/AutoGeneration/Ancestries"))
            AssetDatabase.CreateFolder("Assets/AutoGeneration", "Ancestries");

        var filePath = "Assets/Docs/Ancestries.json";
        var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);
        var result = JsonUtility.FromJson<AncestryDataList>(asset.text);
        foreach (var data in result.datas) GenerateAsset(data);
    }

    private static void GenerateAsset(AncestryData data)
    {
        var asset = new GameObject(data.name);
        AddAncestry(asset, data);

        var backgrounds = CommaSeparatedStrings(data.backgrounds);
        asset.AddComponent<RandomBackgroundProvider>().names = backgrounds;

        var names = CommaSeparatedStrings(data.names);
        asset.AddComponent<RandomNameProvider>().names = names;

        asset.AddComponent<HealthProvider>().value = data.hitPoints;

        var size = (Size)Enum.Parse(typeof(Size), data.size);
        asset.AddComponent<SizeProvider>().value = size;

        asset.AddComponent<SpeedProvider>().value = data.speed;

        AddBoosts(asset, data.boosts, false);
        if (!string.IsNullOrEmpty(data.flaws)) AddBoosts(asset, data.flaws, true);

        CreatePrefab(asset, data.name);
        GameObject.DestroyImmediate(asset);
    }

    private static void AddAncestry(GameObject asset, AncestryData data)
    {
        var script = asset.AddComponent<Ancestry>();
        var rarity = (Rarity)Enum.Parse(typeof(Rarity), data.rarity);
        script.Setup(data.name, data.description, rarity);
    }

    private static void AddBoosts(GameObject asset, string data, bool isFlaw)
    {
        var script = asset.AddComponent<AbilityBoostProvider>();

        var boostNames = CommaSeparatedStrings(data);
        var boosts = new List<AbilityBoost>(boostNames.Count);
        foreach (var boostName in boostNames)
        {
            var boost = (AbilityBoost)Enum.Parse(typeof(AbilityBoost), boostName);
            boosts.Add(boost);
        }

        script.boosts = boosts;
        script.isFlaw = isFlaw;
    }

    private static void CreatePrefab(GameObject asset, string assetName)
    {
        var path = string.Format("Assets/AutoGeneration/Ancestries/{0}.prefab", assetName);
        PrefabUtility.SaveAsPrefabAsset(asset, path);
    }

    private static List<string> CommaSeparatedStrings(string value)
    {
        var components = value.Split(',');
        var result = new List<string>(components.Length);
        foreach (var component in components) result.Add(component.Trim());
        return result;
    }

    [Serializable]
    private class AncestryData
    {
        public string backgrounds;
        public string boosts;
        public string classes;
        public string description;
        public string extraLanguages;
        public string flaws;
        public int hitPoints;
        public string languages;
        public string name;
        public string names;
        public string rarity;
        public string size;
        public string special;
        public int speed;
        public string traits;
        public string vision;
        public int waterSpeed;
    }

    [Serializable]
    private class AncestryDataList
    {
        public List<AncestryData> datas;
    }
}