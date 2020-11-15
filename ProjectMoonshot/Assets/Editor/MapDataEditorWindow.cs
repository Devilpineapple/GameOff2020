using Data;
using UnityEditor;

public class MapDataEditorWindow : ExtendedEditorWindow
{
    public static void Open(MapData dataObject)
    {
        var window = GetWindow<MapDataEditorWindow>("Map Data Editor");
        window.serializedObject = new SerializedObject(dataObject);
    }

    private void OnGUI()
    {
        // serializedObject.Update();
        currentProperty = serializedObject.FindProperty("mapData");
        DrawProperties(currentProperty, true);
        serializedObject.ApplyModifiedProperties();
    }
}