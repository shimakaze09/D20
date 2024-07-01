#region

using UnityEngine;

#endregion

public class MockAttributeProvider : MonoBehaviour, IAttributeProvider
{
    public bool DidSetup { get; private set; }
    public Entity SetupEntity { get; private set; }

    public void Setup(Entity entity)
    {
        DidSetup = true;
        SetupEntity = entity;
    }
}