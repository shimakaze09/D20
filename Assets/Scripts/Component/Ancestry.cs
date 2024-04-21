using System.Collections.Generic;
using UnityEngine;

public interface IAncestry
{
    string Title { get; }
    string Description { get; }
    Rarity Rarity { get; }
    List<IAttributeProvider> AttributeProviders { get; }
}

public class Ancestry : MonoBehaviour, IAncestry
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private Rarity _rarity;
    public string Title => _title;

    public string Description => _description;

    public Rarity Rarity => _rarity;

    public List<IAttributeProvider> AttributeProviders => new(gameObject.GetComponents<IAttributeProvider>());

    public void Setup(string title, string description, Rarity rarity)
    {
        _title = title;
        _description = description;
        _rarity = rarity;
    }
}