using Data;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public static class AssetHandler
{
    // [OnOpenAsset]
    // public static bool OpenEditor(int instanceId, int line)
    // {
    //     var obj = EditorUtility.InstanceIDToObject(instanceId) as MapData;
    //     if (obj == null) return false;
    //     MapDataEditorWindow.Open(obj);
    //     return true;
    // }
}

[CustomEditor(typeof(MapData))]
public class MapDataCustomEditor : Editor
{
    
    // public override void OnInspectorGUI()
    // {
    //     if (GUILayout.Button("Open Editor"))
    //         MapDataEditorWindow.Open((MapData)target);
    // }
}
