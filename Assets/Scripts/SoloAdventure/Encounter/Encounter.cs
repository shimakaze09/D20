using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct MonsterSpawn
{
    public string assetName;
    public Point position;
}

public interface IEncounter
{
    string VictoryEntry { get; }
    string DefeatEntry { get; }
    List<MonsterSpawn> MonsterSpawns { get; }
    List<Point> HeroPositions { get; }
}

public class Encounter : MonoBehaviour, IEncounter
{
    public string VictoryEntry => victoryEntry;
    [SerializeField] private string victoryEntry;

    public string DefeatEntry => defeatEntry;
    [SerializeField] private string defeatEntry;

    public List<MonsterSpawn> MonsterSpawns => monsterSpawns;
    [SerializeField] private List<MonsterSpawn> monsterSpawns;

    public List<Point> HeroPositions => heroPositions;
    [SerializeField] private List<Point> heroPositions;
}