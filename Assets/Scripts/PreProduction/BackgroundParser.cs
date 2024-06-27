using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public static class BackgroundParser
{
    [MenuItem("Pre Production/Generate/Backgrounds")]
    public static void GenerateAll()
    {
        if (!AssetDatabase.IsValidFolder("Assets/AutoGeneration"))
            AssetDatabase.CreateFolder("Assets", "AutoGeneration");
        if (!AssetDatabase.IsValidFolder("Assets/AutoGeneration/Backgrounds"))
            AssetDatabase.CreateFolder("Assets/AutoGeneration", "Backgrounds");

        var filePath = "Assets/Docs/Backgrounds.json";
        var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);
        var result = JsonUtility.FromJson<BackgroundList>(asset.text);
        foreach (var data in result.datas) GenerateAsset(data);
    }

    private static void GenerateAsset(BackgroundData data)
    {
        var asset = new GameObject(data.title);
        AddBackground(asset, data);
        AddBoosts(asset, data);
        AddSkills(asset, data);
        CreatePrefab(asset, data);
        Object.DestroyImmediate(asset);
    }

    private static void AddBackground(GameObject asset, BackgroundData data)
    {
        var bg = asset.AddComponent<Background>();
        bg.Title = data.title;
        bg.Rarity = (Rarity)Enum.Parse(typeof(Rarity), data.rarity);
        bg.Summary = data.summary;
    }

    private static void AddBoosts(GameObject asset, BackgroundData data)
    {
        var boosts = new List<AbilityBoost>();
        foreach (var ability in data.abilities)
        {
            if (string.IsNullOrEmpty(ability))
                continue;

            AbilityBoost boost;
            if (Enum.TryParse(ability, out boost))
                boosts.Add(boost);
            else
                Debug.Log("Unhandled boost: " + boost);
        }

        var boostProvider = asset.AddComponent<AbilityBoostProvider>();
        boostProvider.boosts = boosts;
    }

    private static void AddSkills(GameObject asset, BackgroundData data)
    {
        var valuePairs = new List<SkillsProficiencyProvider.ValuePair>();
        foreach (var name in data.skills)
        {
            if (string.IsNullOrEmpty(name))
                continue;

            Skill skill;
            if (Enum.TryParse(name, out skill))
            {
                var pair = new SkillsProficiencyProvider.ValuePair();
                pair.skill = skill;
                pair.proficiency = Proficiency.Trained;
                valuePairs.Add(pair);
            }
            else
            {
                Debug.LogWarning("Unhandled skill: " + name);
            }
        }

        var provider = asset.AddComponent<SkillsProficiencyProvider>();
        provider.valuePairs = valuePairs;
    }

    private static void CreatePrefab(GameObject asset, BackgroundData data)
    {
        var path = $"Assets/AutoGeneration/Backgrounds/{data.title}.prefab";
        PrefabUtility.SaveAsPrefabAsset(asset, path);
    }

    [Serializable]
    public class BackgroundList
    {
        public List<BackgroundData> datas;
    }

    [Serializable]
    public class BackgroundData
    {
        public string title;
        public List<string> abilities;
        public List<string> skills;
        public List<string> feats;
        public string rarity;
        public string summary;
    }
}