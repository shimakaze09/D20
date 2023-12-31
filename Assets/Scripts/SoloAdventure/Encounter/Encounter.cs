using System;
using System.Collections.Generic;
using UnityEngine;

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
    BoardData BoardData { get; }
    BoardSkin BoardSkin { get; }
}

public class Encounter : MonoBehaviour, IEncounter
{
    [SerializeField] private string victoryEntry;
    [SerializeField] private string defeatEntry;
    [SerializeField] private List<MonsterSpawn> monsterSpawns;
    [SerializeField] private List<Point> heroPositions;
    [SerializeField] private BoardData boardData;
    [SerializeField] private BoardSkin boardSkin;
    public string VictoryEntry => victoryEntry;

    public string DefeatEntry => defeatEntry;

    public List<MonsterSpawn> MonsterSpawns => monsterSpawns;

    public List<Point> HeroPositions => heroPositions;

    public BoardData BoardData => boardData;

    public BoardSkin BoardSkin => boardSkin;
}