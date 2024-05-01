using UnityEditor;
using UnityEngine;

public class BoardTileSystem : EditorWindow
{

    string object_base_name = "";
    int object_id = 1;
    GameObject tile;
    float object_scale;
    float spawn_radius = 5f;
    bool key_tile = false;
    bool teleport_tile = false;
    bool humanSpawn = false;
    bool robotSpawn = false;

    [MenuItem("Custom Utilities/Board Tile System")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BoardTileSystem)); // Gets window of this class
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Board Tiles", EditorStyle.boldLabel);
        object_base_name = EditorGUILayout.TextField("NormalTile", object_base_name);
    }
}
