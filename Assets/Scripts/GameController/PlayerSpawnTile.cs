using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerSpawnTile : Tile
{
    [SerializeField] 
    public GameObject Prefab;

    public PlayerSpawnTile()
    {
    }
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if (Prefab) tileData.gameObject = Prefab;
        base.GetTileData(position, tilemap, ref tileData);
    }

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        if(go)
        go.transform.position = new Vector3(-1, -1, 0);
        return base.StartUp(position, tilemap, go);
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/PlayerSpawnTile")]
    public static void CreateSpawnTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Spawn tile", "New Spawn Tile", "Asset", "Save Spawn Tile", "Assets");
        if (string.IsNullOrEmpty(path))
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PlayerSpawnTile>(), path);
    }

#endif
}
