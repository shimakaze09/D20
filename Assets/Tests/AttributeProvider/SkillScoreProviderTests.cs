using NUnit.Framework;
using UnityEngine;

public class SkillScoreProviderTests
{
    [Test]
    public void AbilityScoreProviderTestsSimplePasses()
    {
        var asset = new GameObject("Hero");
        var provider = asset.AddComponent<AbilityScoreProvider>();
        var json = JsonUtility.ToJson(provider);
        Debug.Log(json);
    }
}