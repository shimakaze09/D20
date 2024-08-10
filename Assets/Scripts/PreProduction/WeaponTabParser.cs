#region

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

#endregion

public class WeaponTabParser : MonoBehaviour
{
    [MenuItem("Pre Production/Convert/Weapons")]
    public static void GenerateAll()
    {
        var result = new RawWeaponContainer();
        result.datas = new List<RawWeaponData>();

        var filePath = "Assets/Docs/WeaponsTabs.txt";
        var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);
        var lines = asset.text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        foreach (var line in lines)
        {
            Debug.Log(line);
            var columns = line.Split("\t".ToCharArray());
            if (columns.Length < 12)
            {
                Debug.Log("Skipping");
                continue;
            }

            var data = new RawWeaponData();
            data.name = columns[0];
            data.weaponType = columns[1];
            data.weaponCategory = columns[2];
            data.weaponGroup = columns[3];
            data.weaponTraits = columns[4];
            data.damage = columns[5];
            data.hands = columns[6];
            data.range = columns[7];
            data.reload = columns[8];
            data.bulk = columns[9];
            data.price = columns[10];
            data.level = columns[11];

            result.datas.Add(data);
        }

        Debug.Log("Result data count: " + result.datas.Count);
        var json = JsonUtility.ToJson(result);

        filePath = string.Format("{0}/Weapons.json", Application.persistentDataPath);
        Debug.Log(filePath);
        File.WriteAllText(filePath, json);
    }

    [Serializable]
    public class RawWeaponContainer
    {
        public List<RawWeaponData> datas;
    }

    [Serializable]
    public class RawWeaponData
    {
        public string name;
        public string weaponType;
        public string weaponCategory;
        public string weaponGroup;
        public string weaponTraits;
        public string damage;
        public string hands;
        public string range;
        public string reload;
        public string bulk;
        public string price;
        public string level;
    }
}