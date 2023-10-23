﻿using System;
using System.Collections.Generic;
using UnityEngine;

public enum ViewZone
{
    Combatant
}

public interface IEntityViewProvider : IDependency<IEntityViewProvider>
{
    GameObject GetView(Entity entity, ViewZone zone);
    void SetView(GameObject view, Entity entity, ViewZone zone);
}

public class EntityViewProvider : MonoBehaviour, IEntityViewProvider
{
    private Dictionary<ViewZone, Dictionary<Entity, GameObject>> mapping =
        new Dictionary<ViewZone, Dictionary<Entity, GameObject>>();
    
    public GameObject GetView(Entity entity, ViewZone zone)
    {
        if (!mapping.ContainsKey(zone))
        {
            Debug.LogError($"No mapping for zone {zone}");
            return null;
        }

        var zoneMap = mapping[zone];
        if (!zoneMap.ContainsKey(entity))
        {
            Debug.LogError($"No mapping for entity {entity.id} in zone {zone}");
            return null;
        }

        return zoneMap[entity];
    }

    public void SetView(GameObject view, Entity entity, ViewZone zone)
    {
        if (!mapping.ContainsKey(zone))
            mapping[zone] = new Dictionary<Entity, GameObject>();

        if (view)
            mapping[zone][entity] = view;
        else
            mapping[zone].Remove(entity);
    }

    private void OnEnable()
    {
        IEntityViewProvider.Register(this);
    }

    private void OnDisable()
    {
        IEntityViewProvider.Reset();
    }
}

public partial struct Entity
{
    public GameObject GetView(ViewZone zone)
    {
        return IEntityViewProvider.Resolve().GetView(this, zone);
    }

    public void SetView(GameObject view, ViewZone zone)
    {
        IEntityViewProvider.Resolve().SetView(view, this, zone);
    }
}