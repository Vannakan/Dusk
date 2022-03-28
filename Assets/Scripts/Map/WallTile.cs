using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTile : TileBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #if UNITY_EDITOR
    [MenuItem("Assets/Create/WallTile")]
    public static void CreateWallTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Wall tile", "New Wall Tile", "Asset", "Save Wall Tile", "Assets");
        if (string.IsNullOrEmpty(path))
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WallTile>(), path);
    }

    #endif
}
