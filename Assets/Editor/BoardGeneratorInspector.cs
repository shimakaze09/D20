#region

using UnityEditor;
using UnityEngine;

#endregion

[CustomEditor(typeof(BoardGenerator))]
public class BoardGeneratorInspector : Editor
{
    // Thanks Mr. R
    // JULY 21, 2017 AT 4:16 PM
    private void OnSceneGUI()
    {
        var current = (BoardGenerator)target;
        var e = Event.current;
        if (!e.shift)
            return;

        switch (e.type)
        {
            case EventType.KeyDown:
            {
                switch (Event.current.keyCode)
                {
                    case KeyCode.LeftArrow:
                        current.MoveMarker(new Point(-1, 0));
                        e.Use();
                        break;
                    case KeyCode.RightArrow:
                        current.MoveMarker(new Point(1, 0));
                        e.Use();
                        break;
                    case KeyCode.UpArrow:
                        current.MoveMarker(new Point(0, 1));
                        e.Use();
                        break;
                    case KeyCode.DownArrow:
                        current.MoveMarker(new Point(0, -1));
                        e.Use();
                        break;
                }

                break;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        var current = (BoardGenerator)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Clear"))
            current.Clear();
        if (GUILayout.Button("Generate"))
            current.Generate();
        if (GUILayout.Button("Generate Perlin"))
            current.GeneratePerlin();
        if (GUILayout.Button("Grow"))
            current.Grow();
        if (GUILayout.Button("Shrink"))
            current.Shrink();
        if (GUILayout.Button("Snap Marker"))
            current.SnapMarker();

        GUILayout.Label("");
        if (GUILayout.Button("Save"))
            current.Save();
        if (GUILayout.Button("Load"))
            current.Load();

        if (GUI.changed)
            current.UpdateMarker();
    }
}