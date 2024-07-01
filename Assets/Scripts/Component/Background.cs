#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public interface IBackground
{
    string Title { get; }
    Rarity Rarity { get; }
    string Summary { get; }
    List<IAttributeProvider> AttributeProviders { get; }
}

public class Background : MonoBehaviour, IBackground
{
    [SerializeField] private string _title;

    [SerializeField] private Rarity _rarity;

    [SerializeField] private string _summary;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public Rarity Rarity
    {
        get => _rarity;
        set => _rarity = value;
    }

    public string Summary
    {
        get => _summary;
        set => _summary = value;
    }

    public List<IAttributeProvider> AttributeProviders => new(gameObject.GetComponents<IAttributeProvider>());
}