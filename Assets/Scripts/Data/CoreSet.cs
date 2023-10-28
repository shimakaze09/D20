using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class CoreSet<T> : ISerializationCallbackReceiver, ICollection<T>,
    IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ISet<T>,
    IDeserializationCallback, ISerializable
{
    [SerializeField] private List<T> values = new();
    private HashSet<T> set = new();

    public void OnAfterDeserialize()
    {
        set.Clear();

        var count = values.Count;
        for (var i = 0; i < count; ++i)
            set.Add(values[i]);
    }

    public void OnBeforeSerialize()
    {
        values.Clear();

        foreach (var value in set)
            values.Add(value);
    }

    public int Count => set.Count;
    public bool IsReadOnly => ((ICollection<T>)set).IsReadOnly;

    public void Add(T item)
    {
        set.Add(item);
    }

    public void Clear()
    {
        set.Clear();
    }

    public bool Contains(T item)
    {
        return set.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        set.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return set.GetEnumerator();
    }

    public bool Remove(T item)
    {
        return set.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((ICollection<T>)set).GetEnumerator();
    }

    bool ISet<T>.Add(T item)
    {
        return set.Add(item);
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        set.ExceptWith(other);
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        set.IntersectWith(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return set.IsProperSubsetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return set.IsProperSupersetOf(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return set.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return set.IsSupersetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return set.Overlaps(other);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return set.SetEquals(other);
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        set.SymmetricExceptWith(other);
    }

    public void UnionWith(IEnumerable<T> other)
    {
        set.UnionWith(other);
    }

    public void OnDeserialization(object sender)
    {
        set.OnDeserialization(sender);
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        set.GetObjectData(info, context);
    }
}