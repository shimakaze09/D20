using System.Collections;
using System.Collections.Generic;

public class PriorityList<T> : IEnumerable<T>, IEnumerable
{
    private readonly List<T> _list = new();
    private bool _isDirty;

    IEnumerator IEnumerable.GetEnumerator()
    {
        Sort();
        return (_list as IEnumerable).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Sort();
        return (_list as IEnumerable<T>).GetEnumerator();
    }

    public void Add(T item)
    {
        _list.Add(item);
        _isDirty = true;
    }

    public void Remove(T item)
    {
        _list.Remove(item);
    }

    private void Sort()
    {
        if (!_isDirty)
            return;

        _list.Sort((x, y) => x.GetType().GetPriority().CompareTo(y.GetType().GetPriority()));
        _isDirty = false;
    }
}