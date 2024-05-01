using UnityEditor;
using UnityEngine;

public class BoardTileSystem : EditorWindow
{

    string object_base_name = "";
    int object_id = 1;
    GameObject board;
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
        board = new GameObject();

        GUILayout.Label("Create Board Tiles", EditorStyles.boldLabel);

        object_base_name = EditorGUILayout.TextField("NormalTile", object_base_name);
        object_id = EditorGUILayout.IntField("Object ID", object_id);
        object_scale = EditorGUILayout.Slider("Scale", object_scale, 0.5f, 3.0f);
        spawn_radius = EditorGUILayout.FloatField("Spawn Radius", spawn_radius);
        tile = EditorGUILayout.ObjectField("tile", tile, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Place Tile"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        
    }
}
